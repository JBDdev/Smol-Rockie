using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockChangeManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GameObject collection;

    private Collection c;
    private RockData rockData;

    [SerializeField] private List<string> names;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<int> indexes;

    // Start is called before the first frame update
    void Start()
    {
        c = collection.GetComponent<Collection>();
        rockData = collection.GetComponent<RockData>();

        names = new List<string>();
        sprites = new List<Sprite>();
        indexes = new List<int>();

        Invoke("UpdateUI", .5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        c = collection.GetComponent<Collection>();
        rockData = collection.GetComponent<RockData>();

        sprites.Clear();
        names.Clear();
        indexes.Clear();

        // Checking which rocks we currently have
        for (int i = 0; i < c.data.collectedRocks.Length; i++)
        {
            // Matching up with cosmetics data
            if (c.data.collectedRocks[i])
            {
                sprites.Add(rockData.rockSprites[i]);
                names.Add(rockData.rockNames[i]);
                indexes.Add(i);
            }
            else
            {
                continue;
            }
        }

        for (int i = 0; i < sprites.Count; i++)
        {
            GameObject newInstance = Instantiate(slotPrefab, inventory.transform); // From Denaton - https://answers.unity.com/questions/260100/instantiate-as-a-child-of-the-parent.html
            newInstance.tag = "showOnRockChange";
            newInstance.GetComponent<InventorySlot>().StoreRockInformation(names[i], sprites[i], indexes[i]);
            newInstance.GetComponent<InventorySlot>().AddItem(sprites[i]);
        }

    }
}
