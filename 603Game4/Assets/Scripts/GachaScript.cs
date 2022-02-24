using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaScript : MonoBehaviour
{
    //Percent of each level, should all add up to one
    [SerializeField]private float fiveStarChance = .05f;
    [SerializeField]private float fourStarChance = .1f;
    [SerializeField]private float threeStarChance = .2f;
    [SerializeField]private float twoStarChance = .25f;
    [SerializeField]private float oneStarChance = .3f;

    //Thresholds for comparing against random
    private float fourStarThreshold;
    private float threeStarThreshold;
    private float twoStarThreshold;
    private float oneStarThreshold;

    [SerializeField] private int numOfRocksForPull = 50;

    //Rewards
    [SerializeField] private int oneStarNumOfRocks = 25;
    [SerializeField] private int twoStarNumOfRocks = 75;
    [SerializeField] private int threeStarNumOfPremiumCurrency = 25;
    [SerializeField] private List<string> fourStarCosmetics;
    [SerializeField] private List<string> fiveStarCosmetics;

    [SerializeField] private int fourStarRepeatNumOfRocks = 200;
    [SerializeField] private int fiveStarRepeatNumOfRocks = 500;

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
        if(Input.GetKeyDown(KeyCode.P))
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

    /// <summary>
    /// A method for performing a gacha pull
    /// </summary>
    public void MineGacha()
    {
        CurrencyManager.playerNumOfRockCurrency -= numOfRocksForPull;

        float chance = Random.Range(0, 100);
        
        //One Star
        if (chance <= oneStarThreshold)
        {
            Debug.Log("One Star Reward");
            CurrencyManager.playerNumOfRockCurrency += oneStarNumOfRocks;
        }
        //Two Star
        else if (chance <= twoStarThreshold)
        {
            Debug.Log("Two Star Reward");
            CurrencyManager.playerNumOfRockCurrency += twoStarNumOfRocks;
        }
        //Three Star
        else if (chance <= threeStarThreshold)
        {
            Debug.Log("Three Star Reward");
            CurrencyManager.playerNumOfPremiumCurrency += threeStarNumOfPremiumCurrency;
        }
        //Four Star
        else if (chance <= fourStarThreshold)
        {
            Debug.Log("Four Star Reward");

            //Get a Random Four Star Cosmetic
            string temp = fourStarCosmetics[Random.Range(0, fourStarCosmetics.Count - 1)];

            Debug.Log(temp);

            if (CurrencyManager.cosmetics.Count > 0)
            {
                foreach (string c in CurrencyManager.cosmetics)
                {
                    if (c == temp)
                    {
                        Debug.Log("This item is already owned");
                        //This item is already owned
                        CurrencyManager.playerNumOfRockCurrency += fourStarRepeatNumOfRocks;
                        return;
                    }
                }
            }

            CurrencyManager.cosmetics.Add(temp);
        }
        //Five Star
        else
        {
            Debug.Log("Five Star Reward");

            //Get a Random Five Star Cosmetic
            string temp = fiveStarCosmetics[Random.Range(0, fiveStarCosmetics.Count - 1)];

            Debug.Log(temp);

            if (CurrencyManager.rockCosmetics.Count > 0)
            {
                foreach (string c in CurrencyManager.rockCosmetics)
                {
                    if (c == temp)
                    {
                        //This item is already owned
                        Debug.Log("This item is already owned");
                        CurrencyManager.playerNumOfRockCurrency += fiveStarRepeatNumOfRocks;
                        return;
                    }
                }
            }

            CurrencyManager.rockCosmetics.Add(temp);
        }
    }
}
