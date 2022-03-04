// Base code source: Katarina Tretter

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ShopMenuState
{
    Game,
    Confirm,
    Success
}

public class ShopMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] confirmObjects;
    [SerializeField] private GameObject[] successObjects;

    public ShopMenuState currentShopMenuState = ShopMenuState.Game;

    public int numToGain = 0;

    // Start is called before the first frame update
    void Start()
    {
        confirmObjects = GameObject.FindGameObjectsWithTag("showOnConfirm");
        successObjects = GameObject.FindGameObjectsWithTag("showOnSuccess");

        // Hide menus
        HideMenu(confirmObjects);
        HideMenu(successObjects);  
    }

    //---------METHODS---------

    /// <summary>
    /// Toggles the selected menu on or off
    /// </summary>
    /// <param name="menuObjects">Menu items to toggle</param>
    /// <param name="menuState">Which menu is going to be toggled</param>
    public void MenuControl(GameObject[] menuObjects, ShopMenuState menuState)
    {
        // If currently in game, and click shop button
        if (currentShopMenuState == ShopMenuState.Game && menuState == ShopMenuState.Confirm)
        {
            currentShopMenuState = ShopMenuState.Confirm;
            ShowMenu(confirmObjects);
        }
        // If currently in confirm, and go back
        else if (currentShopMenuState == ShopMenuState.Confirm && menuState == ShopMenuState.Game)
        {
            HideMenu(confirmObjects);
            currentShopMenuState = ShopMenuState.Game;
        }
        // If in confirm menu, and go to success
        else if (currentShopMenuState == ShopMenuState.Confirm && menuState == ShopMenuState.Success)
        {
            HideMenu(confirmObjects);
            currentShopMenuState = ShopMenuState.Success;
            ShowMenu(successObjects);
        }
        // If in success, and go back
        else if (currentShopMenuState == ShopMenuState.Success && menuState == ShopMenuState.Game)
        {
            HideMenu(successObjects);
            currentShopMenuState = ShopMenuState.Game;
        }
    }

    /// <summary>
    /// Hides the objects in the menu
    /// </summary>
    /// <param name="menuObjects">Menuy items to hide</param>
    public void ShowMenu(GameObject[] menuObjects)
    {
        // Set al of the UI elements active
        foreach (GameObject g in menuObjects)
        {
            g.SetActive(true);
        }
    }

    /// <summary>
	/// Hides the objects in the menu
	/// </summary>
	/// <param name="menuObjects"Menu items to hide</param>
	public void HideMenu(GameObject[] menuObjects)
    {
        // Set all of the UI elements active
        foreach (GameObject g in menuObjects)
        {
            g.SetActive(false);
        }
    }

    /// <summary>
	/// Checks which button was pressed
	/// <summary>
	/// <aparm name="name"Name of button pressed</param>
	public void ButtonPress(string name)
    {
        // If clicked convert
        if (name == "convert")
        {
            MenuControl(confirmObjects, ShopMenuState.Confirm);
        }
        // If clicked purchase
        else if (name == "purchase")
        {
            MenuControl(confirmObjects, ShopMenuState.Confirm);
        }
        // If clicked cancel
        else if (name == "cancel")
        {
            MenuControl(confirmObjects, ShopMenuState.Game);
        }
        // If clicked confirm
        else if (name == "confirm")
        {
            MenuControl(successObjects, ShopMenuState.Success);
        }
        // If clicked okay
        else if (name == "okay")
        {
            MenuControl(successObjects, ShopMenuState.Game);
        }
    }
}
