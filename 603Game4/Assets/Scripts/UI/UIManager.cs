// Base code source: Katarina Tretter

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum MenuState
{
    Game,
    Pause,
    Options,
    Inventory,
    Camera,
    RockChange
}

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    [SerializeField] private GameObject[] pauseObjects;
    [SerializeField] private GameObject[] optionObjects;
    [SerializeField] private GameObject[] inventoryObjects;
    [SerializeField] private GameObject[] rockChangeObjects;
    [SerializeField] private Text rockNumCount;

    public MenuState currentMenuState = MenuState.Game;

    // Start is called before the first frame update
    void Start()
    {
        // Set gametime to active
        Time.timeScale = 1;

        // Store all UI elements in respective categorieas
        gameObjects = GameObject.FindGameObjectsWithTag("showOnGame");
        pauseObjects = GameObject.FindGameObjectsWithTag("showOnPause");
        optionObjects = GameObject.FindGameObjectsWithTag("showOnOptions");
        inventoryObjects = GameObject.FindGameObjectsWithTag("showOnInventory");
        rockChangeObjects = GameObject.FindGameObjectsWithTag("showOnRockChange");

        // Hide menus
        HideMenu(pauseObjects);
        HideMenu(optionObjects);
        HideMenu(inventoryObjects);
        HideMenu(rockChangeObjects);

        if (rockNumCount != null)
        {
            rockNumCount.text = "Rocks Owned: " + CurrencyManager.playerNumOfRockCosmetics;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentMenuState)
        {
            case MenuState.Game:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(pauseObjects, MenuState.Pause);
                }
                break;
            case MenuState.Pause:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(pauseObjects, MenuState.Game);
                }
                break;
            case MenuState.Options:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(optionObjects, MenuState.Game);
                }
                break;
            case MenuState.Inventory:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(inventoryObjects, MenuState.Game);
                }
                break;
            case MenuState.Camera:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(gameObjects, MenuState.Game);
                }
                break;
            // If somehow not in Game state, Menu State, or Options state, assume it is menu and can go back to game state
            default:
                // If ESC is pressed
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    MenuControl(pauseObjects, MenuState.Game);
                }
                break;
        }
    }

    //---------METHODS---------

    /// <summary>
    /// Toggles the selected menu on or off
    /// </summary>
    /// <param name="menuObjects">Menu items to toggle</param>
    /// <param name="menuState">Which menu is going to be toggled</param>
    public void MenuControl(GameObject[] menuObjects, MenuState menuState)
    {
        // If in pause menu already, clicked on options menu
        if (currentMenuState == MenuState.Pause && menuState == MenuState.Options)
        {
            HideMenu(pauseObjects);
            currentMenuState = menuState;
            ShowMenu(optionObjects);
        }
        // If in pause menu already, clicked on inventory menu
        else if (currentMenuState == MenuState.Pause && menuState == MenuState.Inventory)
        {
            HideMenu(pauseObjects);
            currentMenuState = menuState;
            ShowMenu(inventoryObjects);
        }
        // If in game, clicked on camera
        else if (currentMenuState == MenuState.Game && menuState == MenuState.Camera)
        {
            HideMenu(gameObjects);
            currentMenuState = menuState;
        }
        // If in game, clicked on rock change
        else if (currentMenuState == MenuState.Game && menuState == MenuState.RockChange)
        {
            currentMenuState = MenuState.RockChange;
            ShowMenu(rockChangeObjects);
        }
        else if (currentMenuState == MenuState.RockChange && menuState == MenuState.RockChange)
        {
            return;
        }
        // If in rock change, go back to game
        else if (currentMenuState == MenuState.RockChange && menuState == MenuState.Game)
        {
            HideMenu(rockChangeObjects);
            currentMenuState = MenuState.Game;
        }
        // If in options menu, clicked back arrow
        else if (currentMenuState == MenuState.Options && menuState == MenuState.Pause)
        {
            HideMenu(optionObjects);
            currentMenuState = menuState;
            ShowMenu(pauseObjects);
        }
        // If in inventory menu, clicked back arrow
        else if (currentMenuState == MenuState.Inventory && menuState == MenuState.Pause)
        {
            HideMenu(inventoryObjects);
            currentMenuState = menuState;
            ShowMenu(pauseObjects);
        }
        // If in camera, unhide game
        else if(currentMenuState == MenuState.Camera && menuState == MenuState.Game)
        {
            currentMenuState = menuState;
            ShowMenu(gameObjects);
        }
        // If not in menu already
        else
        {
            // If poaused, show UI elements with correct label
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                currentMenuState = menuState;
                ShowMenu(menuObjects);
                HideMenu(gameObjects);
            }
            // Unpausing game hides UI elements with correct label
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                currentMenuState = MenuState.Game;
                HideMenu(menuObjects);
                ShowMenu(gameObjects);
            }
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
        // If paused, show pause menu
        if (name == "pause")
        {
            MenuControl(pauseObjects, MenuState.Pause);
        }
        // If clicked resume, resume game
        else if (name == "resume")
        {
            MenuControl(pauseObjects, MenuState.Game);
        }
        // If clicked options, show options
        else if (name == "options")
        {
            MenuControl(optionObjects, MenuState.Options);
        }
        // If clicked inventory, show inventowy
        else if (name == "inventory")
        {
            MenuControl(inventoryObjects, MenuState.Inventory);
        }
        // If clicked back, go back to pause menu
        else if (name == "back")
        {
            MenuControl(pauseObjects, MenuState.Pause);
        }
        // If clicked camera, remove game overlay
        else if (name == "cameraStart")
        {
            MenuControl(gameObjects, MenuState.Camera);
        }
        // bring back game overlay
        else if (name == "cameraEnd")
        {
            MenuControl(gameObjects, MenuState.Game);
        }
        // If clicked rock change
        else if (name == "rockChangeOpen")
        {
            MenuControl(rockChangeObjects, MenuState.RockChange);
        }
        // bring back to game overlay
        else if (name == "rockChangeClose")
        {
            MenuControl(rockChangeObjects, MenuState.Game);
        }
    }
}
