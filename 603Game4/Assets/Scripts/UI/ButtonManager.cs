// Base code source: Katarina Tretter

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject uI;
    [SerializeField] private GameObject gM;

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
}