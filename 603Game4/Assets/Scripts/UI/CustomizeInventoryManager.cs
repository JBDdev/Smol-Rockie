using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizeInventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private GameObject collection;

    private Collection c;
    private CosmeticsData cData;

    [SerializeField] private List<string> names;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private List<string> types;

    // Start is called before the first frame update
    void Start()
    {
        c = collection.GetComponent<Collection>();
        cData = collection.GetComponent<CosmeticsData>();

        names = new List<string>();
        sprites = new List<Sprite>();
        types = new List<string>();

        Invoke("UpdateUI", .5f);
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateUI();
    }

    public void UpdateUI()
    {
        c = collection.GetComponent<Collection>();
        cData = collection.GetComponent<CosmeticsData>();

        sprites.Clear();
        types.Clear();
        names.Clear();

        // Checking which 5 star cosmetics we currently have
        for (int i = 0; i < c.data.fiveStarCos.Length; i++)
        {
            // Matching up with cosmetics data
            if (c.data.fiveStarCos[i])
            {
                sprites.Add(cData.fiveStarSprites[i]);
                types.Add(cData.fiveStarTypes[i]);
                names.Add(cData.fiveStarNames[i]);
            }
            else
            {
                continue;
            }
        }
        // Checking which 4 star cosmetics we currently have
        for (int i = 0; i < c.data.fourStarCos.Length; i++)
        {
            // Matching up with cosmetics data
            if (c.data.fourStarCos[i])
            {
                sprites.Add(cData.fourStarSprites[i]);
                types.Add(cData.fourStarTypes[i]);
                names.Add(cData.fourStarNames[i]);
            }
            else
            {
                continue;
            }
        }

        for (int i = 0; i < sprites.Count; i++)
        {
            GameObject newInstance = Instantiate(slotPrefab, inventory.transform); // From Denaton - https://answers.unity.com/questions/260100/instantiate-as-a-child-of-the-parent.html
            newInstance.GetComponent<InventorySlot>().StoreInformation(names[i], types[i], sprites[i]);
            newInstance.GetComponent<InventorySlot>().AddItem(sprites[i]);
        }
    }
}
