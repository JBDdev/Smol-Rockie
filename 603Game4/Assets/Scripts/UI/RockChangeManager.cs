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

    // Start is called before the first frame update
    void Start()
    {
        c = collection.GetComponent<Collection>();
        rockData = collection.GetComponent<RockData>();

        // Checking which rocks we currently have
        for (int i = 0; i < c.data.collectedRocks.Length; i++)
        {
            // Matching up with cosmetics data
            if (c.data.collectedRocks[i])
            {
                sprites.Add(rockData.rockSprites[i]);
                names.Add(rockData.rockNames[i]);
            }
            else
            {
                continue;
            }
        }

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            GameObject newInstance = Instantiate(slotPrefab, inventory.transform); // From Denaton - https://answers.unity.com/questions/260100/instantiate-as-a-child-of-the-parent.html
            newInstance.tag = "showOnRockChange";
            newInstance.GetComponent<InventorySlot>().StoreRockInformation(names[i], sprites[i]);
            newInstance.GetComponent<InventorySlot>().AddItem(sprites[i]);
        }

    }
}
