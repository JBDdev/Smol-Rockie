using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Collection : MonoBehaviour
{
    public CollectionData data;
    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists("./playerdata.txt"))
        {

            data = new CollectionData(gameObject.GetComponent<RockData>().NumRocks, gameObject.GetComponent<CosmeticsData>().NumFourStars, gameObject.GetComponent<CosmeticsData>().NumFiveStars);
            string output = JsonUtility.ToJson(data, true);

            //Write values to file
            FileStream stream = new FileStream("./playerdata.txt", FileMode.OpenOrCreate);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(output);
            }
        }
        else
        {
            string output;
            using (StreamReader reader = new StreamReader("./playerdata.txt")) 
            {
                output = reader.ReadToEnd();
            }
               
            data = JsonUtility.FromJson<CollectionData>(output);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
            UpdateFile();
    }

    // This function should be called whenever updates to the player's collection (i.e. gained currency, new item from gacha pull, etc.)
    public void UpdateFile()
    {
        string output = JsonUtility.ToJson(data, true);

        //Write values to file
        FileStream stream = new FileStream("./playerdata.txt", FileMode.Create);
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.WriteLine(output);
        }
    }

    
}

//Data was split into a separate object to make use of Unity's JSON Serialization Utility
[System.Serializable]
public class CollectionData
{
    public CollectionData(int numRocks, int numFourStars, int numFiveStars) 
    {
        //Default Collection values
        collectedRocks = new bool[numRocks];
        fourStarCos = new bool[numFourStars];
        fiveStarCos = new bool[numFiveStars];
        currentRock = -1;
        hat = -1;
        face = -1;
        neck = -1;
    }

    public CollectionData() 
    {
    
    }
    //Index values for collected items
    public bool[] collectedRocks;
    public bool[] fourStarCos;
    public bool[] fiveStarCos;

    [Header("Current Pet Rock")]
    public int currentRock;
    public int hat;
    public int face;
    public int neck;

    [Header("Resources")]
    public int money;
    public int premiumMoney;
}
