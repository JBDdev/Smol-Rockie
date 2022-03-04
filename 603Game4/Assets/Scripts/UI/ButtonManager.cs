// Base code source: Katarina Tretter

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Tooltip("UI Manager")][SerializeField] private GameObject uI;
    [Tooltip("Game Manager")][SerializeField] private GameObject gM;
    [Tooltip("Shop Menu Manager")][SerializeField] private GameObject sM;

    private Collection collectionScript;
    private RockData rockScript;

    public void Start()
    {
        GameObject gameData = GameObject.Find("GameData");
        collectionScript = gameData.GetComponent<Collection>();
        rockScript = gameData.GetComponent<RockData>();
    }

    //---------GENERAL BUTTONS---------

    public void OnStart()
    {
        Debug.Log("Clicked Start");
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void OnResume()
    {
        Debug.Log("Clicked Resume");
        uI.GetComponent<UIManager>().ButtonPress("resume");
    }

    public void OnPause()
    {
        Debug.Log("Clicked Pause");
        uI.GetComponent < UIManager>().ButtonPress("pause");
    }

    public void OnOptions()
    {
        Debug.Log("Clicked Options");
        uI.GetComponent<UIManager>().ButtonPress("options");
    }

    public void OnBack()
    {
        Debug.Log("Clicked Back");
        uI.GetComponent<UIManager>().ButtonPress("back");
    }

    public void OnCredits()
    {
        Debug.Log("Clicked Credits");
        SceneManager.LoadScene("CreditsMenu");
    }

    public void OnMainMenu()
    {
        Debug.Log("Clicked Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnQuit()
    {
        Debug.Log("Clicked Quit");
        Application.Quit();
    }

    public void OnShop()
    {
        Debug.Log("Clicked Shop");
        SceneManager.LoadScene("ShopMenu");
    }

    public void OnGatcha()
    {
        Debug.Log("Clicked Gatcha");
        SceneManager.LoadScene("DestinyScene");
    }

    public void OnCustomize()
    {
        Debug.Log("Clicked Customize");
        SceneManager.LoadScene("CustomizeMenu");
    }

    public void OnInventory()
    {
        Debug.Log("Clicked Inventory");
        uI.GetComponent<UIManager>().ButtonPress("inventory");
    }

    public void OnCamera()
    {
        Debug.Log("Clicked Camera");
        uI.GetComponent<UIManager>().ButtonPress("camera");
    }

    public void OnClaim()
    {
        Debug.Log("Clicked Claim");
        gM.GetComponent<GameManager>().ClaimRocks();
    }

    //---------SHOP BUTTONS---------
    public void OnConvert()
    {
        sM.GetComponent<ShopMenuManager>().numToGain = -5;
        Debug.Log("Clicked Convert");
        sM.GetComponent<ShopMenuManager>().ButtonPress("convert");
    }

    public void OnPurchase(int gain)
    {
        Debug.Log("Clicked Purchase");
        sM.GetComponent<ShopMenuManager>().numToGain = gain;
        sM.GetComponent<ShopMenuManager>().ButtonPress("purchase");
    }

    public void OnCancel()
    {
        sM.GetComponent<ShopMenuManager>().numToGain = 0;
        Debug.Log("Clicked Cancel");
        sM.GetComponent<ShopMenuManager>().ButtonPress("cancel");
    }

    public void OnConfirm()
    {
        //If Erika Rock
        if (sM.GetComponent<ShopMenuManager>().numToGain == -100)
        {
            int index = 0;
            for (int i = 0; i < rockScript.rockNames.Count; i++)
            {
                if (rockScript.rockNames[i] == "Erika")
                {
                    index = i;
                }
            }

            CurrencyManager.playerNumOfRockCosmetics++;

            collectionScript.data.collectedRocks[index] = true;

            collectionScript.UpdateFile();
        }
        //If Converting
        else if(sM.GetComponent<ShopMenuManager>().numToGain == -5)
        {
            CurrencyManager.playerNumOfRockCurrency += 100;
        }

        CurrencyManager.playerNumOfPremiumCurrency += sM.GetComponent<ShopMenuManager>().numToGain;

        Debug.Log("Clicked Confirm");
        sM.GetComponent<ShopMenuManager>().ButtonPress("confirm");

        sM.GetComponent<ShopMenuManager>().numToGain = 0;
    }

    public void OnOkay()
    {
        Debug.Log("Clicked Okay");
        sM.GetComponent<ShopMenuManager>().ButtonPress("okay");
    }

    //---------CUSTOMIZE BUTTONS---------
    public void OnRockChangeOpen()
    {
        Debug.Log("Clicked Rock Change Open");
        uI.GetComponent<UIManager>().ButtonPress("rockChangeOpen");
    }

    public void OnRockChangeClose()
    {
        Debug.Log("Clicked Rock Change Close");
        uI.GetComponent<UIManager>().ButtonPress("rockChangeClose");
    }
}
