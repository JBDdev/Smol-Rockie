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
    }

    // Update is called once per frame
    void Update()
    {
        rockCurrencyText.text = "Rock Currency: " + CurrencyManager.playerNumOfRockCurrency;
        premiumCurrencyText.text = "Premium Currency: " + CurrencyManager.playerNumOfPremiumCurrency;
        rocksHeldText.text = "Rocks Held: " + rocksHeld + "/" + maxRocksHeld;

        if (Input.GetKeyDown(KeyCode.C))
        {
            CollectRockCurrency();
        }
    }

    public IEnumerator GainRockCurrency()
    {
        yield return new WaitForSeconds(timeBetweenRockGain);

        rocksHeld++;

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
            StartCoroutine(GainRockCurrency());
        }
        else
        {
            rocksHeld = 0;
        }
    }
}
