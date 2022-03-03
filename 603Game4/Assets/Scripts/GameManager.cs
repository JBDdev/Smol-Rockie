using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text rockCurrencyText;
    public Text premiumCurrencyText;
    public Text rocksHeldText;

    [SerializeField] private float timeBetweenRockGain = 2f;
    [SerializeField] private int maxRocksHeld = 100;
    private int rocksHeld = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GainRockCurrency());
        Invoke("LoadRockie", 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        //rockCurrencyText.text = "Rock Currency: " + CurrencyManager.playerNumOfRockCurrency;
        //premiumCurrencyText.text = "Premium Currency: " + CurrencyManager.playerNumOfPremiumCurrency;
        //rocksHeldText.text = "Rocks Held: " + rocksHeld + "/" + maxRocksHeld;

        if (Input.GetKeyDown(KeyCode.C))
        {
            CollectRockCurrency();
        }
    }

    public IEnumerator GainRockCurrency()
    {
        yield return new WaitForSeconds(timeBetweenRockGain);

        rocksHeld++;
        CurrencyManager.playerNumOfRocksHeld++;

        if (rocksHeld < maxRocksHeld)
        {
            StartCoroutine(GainRockCurrency());
        }
    }

    public void CollectRockCurrency()
    {
        CurrencyManager.playerNumOfRockCurrency += rocksHeld;

        if (rocksHeld >= maxRocksHeld)
        {
            rocksHeld = 0;
            CurrencyManager.playerNumOfRocksHeld = 0;
            StartCoroutine(GainRockCurrency());
        }
        else
        {
            rocksHeld = 0;
            CurrencyManager.playerNumOfRocksHeld = 0;
        }
    }

    /// <summary>
    /// Sends the current number of rock currency to the UI
    /// </summary>
    public string DisplayRockCurrency()
    {
        return CurrencyManager.playerNumOfRockCurrency.ToString();
    }

    /// <summary>
    /// Sends the current number of premium currency to the UI
    /// </summary>
    public string DisplayPremiium()
    {
        return CurrencyManager.playerNumOfPremiumCurrency.ToString();
    }

    /// <summary>
    /// Sends the current number of rocks held to the UI
    /// </summary>
    public string DisplayRocksHeld()
    {
        return string.Format("{0}/{1}", CurrencyManager.playerNumOfRocksHeld, maxRocksHeld);
    }

    public void ClaimRocks()
    {
        CollectRockCurrency();
    }

    public void LoadRockie() 
    {
        GameObject gameData = GameObject.Find("GameData");
        GameObject rockieParent = GameObject.Find("Rockie");

        GameObject rockie = Instantiate(gameData.GetComponent<RockData>().rockPrefabs[gameData.GetComponent<Collection>().data.currentRock], rockieParent.transform);

        if (gameData.GetComponent<Collection>().data.hat != -1) 
        {
             if (gameData.GetComponent<Collection>().data.hat < gameData.GetComponent<CosmeticsData>().NumFourStars)
            {
                rockie.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gameData.GetComponent<CosmeticsData>().fourStarSprites[gameData.GetComponent<Collection>().data.hat];
            }
            else 
            {
                rockie.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = gameData.GetComponent<CosmeticsData>().fiveStarSprites[gameData.GetComponent<Collection>().data.hat - gameData.GetComponent<CosmeticsData>().NumFourStars];
            }
        }

        if (gameData.GetComponent<Collection>().data.face != -1)
        {
            if (gameData.GetComponent<Collection>().data.face < gameData.GetComponent<CosmeticsData>().NumFourStars)
            {
                rockie.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gameData.GetComponent<CosmeticsData>().fourStarSprites[gameData.GetComponent<Collection>().data.face];
            }
            else
            {
                rockie.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = gameData.GetComponent<CosmeticsData>().fiveStarSprites[gameData.GetComponent<Collection>().data.face - gameData.GetComponent<CosmeticsData>().NumFourStars];
            }
        }

        if (gameData.GetComponent<Collection>().data.neck != -1)
        {
            if (gameData.GetComponent<Collection>().data.neck < gameData.GetComponent<CosmeticsData>().NumFourStars)
            {
                rockie.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gameData.GetComponent<CosmeticsData>().fourStarSprites[gameData.GetComponent<Collection>().data.neck];
            }
            else
            {
                rockie.transform.GetChild(2).GetComponent<SpriteRenderer>().sprite = gameData.GetComponent<CosmeticsData>().fiveStarSprites[gameData.GetComponent<Collection>().data.neck - gameData.GetComponent<CosmeticsData>().NumFourStars];
            }
        }




    }
}
