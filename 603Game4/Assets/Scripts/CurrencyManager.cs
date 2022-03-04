using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static int playerNumOfRockCurrency = 5000;
    public static int playerNumOfPremiumCurrency = 0;
    public static int playerNumOfRocksHeld = 0;
    public static int playerNumOfRockCosmetics = 0;

    public static void SetUp(int rockCurrency, int premiumCurrency, int rockScore)
    {
        playerNumOfRockCurrency = rockCurrency;
        playerNumOfPremiumCurrency = premiumCurrency;
        playerNumOfRockCosmetics = rockScore;
    }

}