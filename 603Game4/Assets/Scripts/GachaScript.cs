using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GachaScript : MonoBehaviour
{
    private bool isPulling = false;

    //Percent of each level, should all add up to one
    [Header("Chance Percents")]
    [SerializeField] private float fiveStarChance = .05f;
    [SerializeField] private float fourStarChance = .1f;
    [SerializeField] private float threeStarChance = .2f;
    [SerializeField] private float twoStarChance = .25f;
    [SerializeField] private float oneStarChance = .3f;

    //Thresholds for comparing against random
    private float fourStarThreshold;
    private float threeStarThreshold;
    private float twoStarThreshold;
    private float oneStarThreshold;

    [Header("Costs and Rewards")]
    [SerializeField] private int numOfRocksForPull = 50;

    //Rewards
    [SerializeField] private int oneStarNumOfRocks = 25;
    [SerializeField] private int twoStarNumOfRocks = 75;
    [SerializeField] private int threeStarNumOfPremiumCurrency = 25;
    [SerializeField] private List<string> fourStarCosmetics;
    [SerializeField] private List<string> fiveStarCosmetics;

    [SerializeField] private int fourStarRepeatNumOfRocks = 200;
    [SerializeField] private int fiveStarRepeatNumOfRocks = 500;

    [SerializeField] private int fourStarPityThreshold = 10;
    [SerializeField] private int fiveStarPityThreshold = 50;

    [Header("Visuals")]
    public GameObject trailPrefab;
    private GameObject trail;
    private float timeForUp = 1;
    private ParticleSystem.MainModule p;
    protected DOTweenPath path;
    [SerializeField] private int wayPointToChangeColor = 9;
    [SerializeField] private float rewardDisplayTime = 2;

    //Variables for color change
    private int colorIndex = 0;
    public Color[] rewardColors = new Color[5];

    [Header("Images For Testing")]
    [SerializeField] private GameObject oneTwoStar;
    [SerializeField] private GameObject threeStar;
    [SerializeField] private GameObject fourStar;
    [SerializeField] private GameObject fiveStar;

    private GameObject rewardToSpawn;

    private int fourStarCounter = 0;
    private int fiveStarCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Set thresholds based on percentages
        oneStarThreshold = 100 * oneStarChance;
        twoStarThreshold = oneStarThreshold + (100 * twoStarChance);
        threeStarThreshold = twoStarThreshold + (100 * threeStarChance);
        fourStarThreshold = threeStarThreshold + (100 * fourStarChance);

        Debug.Log(oneStarThreshold);
        Debug.Log(twoStarThreshold);
        Debug.Log(threeStarThreshold);
        Debug.Log(fourStarThreshold);
    }

    // Update is called once per frame
    void Update()
    {
        //Test Gacha Pull
        if (Input.GetKeyDown(KeyCode.P) && !isPulling)
        {
            if (CurrencyManager.playerNumOfRockCurrency >= numOfRocksForPull)
            {
                MineGacha();
            }
            else
            {
                Debug.Log("Not enough rock currency");
            }

        }
    }

    public void ChangeTrailColor(int wayPointindex)
    {
        if (wayPointindex == wayPointToChangeColor)
        {
            p = trail.GetComponentInChildren<ParticleSystem>().main;
            p.startColor = new ParticleSystem.MinMaxGradient(rewardColors[colorIndex]);
        }
    }

    /// <summary>
    /// A method for performing a gacha pull
    /// </summary>
    public void MineGacha()
    {
        isPulling = true;

        CurrencyManager.playerNumOfRockCurrency -= numOfRocksForPull;
        float chance = 0;

        if (fiveStarCounter >= fiveStarPityThreshold)
        {
            Debug.Log("5 Star Pity");
            chance = fourStarThreshold + 1;
        }
        else if (fourStarCounter >= fourStarPityThreshold)
        {
            Debug.Log("4 Star Pity");
            chance = fourStarThreshold - 1;
        }
        else
        {
            chance = Random.Range(0, 100);
        }

        fourStarCounter++;
        fiveStarCounter++;

        Debug.Log(fourStarCounter);
        Debug.Log(fiveStarCounter);

        //One Star
        if (chance <= oneStarThreshold)
        {
            colorIndex = 0;
        }
        //Two Star
        else if (chance <= twoStarThreshold)
        {
            colorIndex = 1;
        }
        //Three Star
        else if (chance <= threeStarThreshold)
        {
            colorIndex = 2;
        }
        //Four Star
        else if (chance <= fourStarThreshold)
        {
            colorIndex = 3;
            fourStarCounter = 0;
        }
        //Five Star
        else
        {
            colorIndex = 4;
            fiveStarCounter = 0;
        }

        //Spawn Visual Trail
        trail = Instantiate(trailPrefab);

        path = trail.GetComponent<DOTweenPath>();
        path.tween.OnWaypointChange(ChangeTrailColor).OnComplete(GiveReward);
    }

    /// <summary>
    /// Gives the reward to the player after the trail is complete
    /// </summary>
    public void GiveReward()
    {
        switch (colorIndex)
        {
            //One Star
            case 0:
                rewardToSpawn = oneTwoStar;
                CurrencyManager.playerNumOfRockCurrency += oneStarNumOfRocks;
                break;
            //Two Star
            case 1:
                rewardToSpawn = oneTwoStar;
                CurrencyManager.playerNumOfRockCurrency += twoStarNumOfRocks;
                break;
            //Three Star
            case 2:
                rewardToSpawn = threeStar;
                CurrencyManager.playerNumOfPremiumCurrency += threeStarNumOfPremiumCurrency;
                break;
            //Four Star
            case 3:
                
                //Get a Random Four Star Cosmetic
                string temp4 = fourStarCosmetics[Random.Range(0, fourStarCosmetics.Count - 1)];

                Debug.Log(temp4);

                if (CurrencyManager.cosmetics.Count > 0)
                {
                    foreach (string c in CurrencyManager.cosmetics)
                    {
                        if (c == temp4)
                        {
                            Debug.Log("This item is already owned");
                            //This item is already owned
                            CurrencyManager.playerNumOfRockCurrency += fourStarRepeatNumOfRocks;
                            Destroy(trail);
                            return;
                        }
                    }
                }

                rewardToSpawn = fourStar;
                CurrencyManager.cosmetics.Add(temp4);
                break;
            //Five Star
            case 4:

                //Get a Random Five Star Cosmetic
                string temp5 = fiveStarCosmetics[Random.Range(0, fiveStarCosmetics.Count - 1)];

                Debug.Log(temp5);

                if (CurrencyManager.rockCosmetics.Count > 0)
                {
                    foreach (string c in CurrencyManager.rockCosmetics)
                    {
                        if (c == temp5)
                        {
                            //This item is already owned
                            Debug.Log("This item is already owned");
                            CurrencyManager.playerNumOfRockCurrency += fiveStarRepeatNumOfRocks;
                            Destroy(trail);
                            return;
                        }
                    }
                }

                rewardToSpawn = fiveStar;
                CurrencyManager.rockCosmetics.Add(temp5);

                break;
        }

        StartCoroutine(showRewardImage());
    }

    /// <summary>
    /// Displays a image of the reward recieved
    /// </summary>
    /// <returns></returns>
    public IEnumerator showRewardImage()
    {
        GameObject temp = Instantiate(rewardToSpawn);
        yield return new WaitForSeconds(rewardDisplayTime);
        Destroy(temp);
        Destroy(trail);
        isPulling = false;
    }
}
