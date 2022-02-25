using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Collection : MonoBehaviour
{
    //Index values for collected items
    public int[] collectedRocks;
    public int[] fourStarCos;
    public int[] fiveStarCos;

    [Header("Current Pet Rock")]
    public int currentRock;
    public int hat;
    public int face;
    public int neck;

    [Header("Resources")]
    public int money;
    public int premiumMoney;

    // Start is called before the first frame update
    void Start()
    {
        //Psuedocode hellscape begins here (Determine file location where the data will be stored)

        /* Check to see if collection file exists 
         * 
         * if doesn't exist: create the file. Setup default values for collection, then write data to file.
         *
         * if exists, take the json data and convert it into vars for this obj.
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function should be called whenever updates to the player's collection (i.e. gained currency, new item from gacha pull, etc.)
    public void UpdateFile() 
    {
        //Do a ToJson on this object (w/ pretty print) and write it to the collection.json file
    }
}
