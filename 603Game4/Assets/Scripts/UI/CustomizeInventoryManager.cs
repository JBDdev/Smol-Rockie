using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeInventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject slotPrefab;

    private List<Sprite> sprites;
    private List<string> types;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            GameObject newInstance = Instantiate(slotPrefab, transform); // From Denaton - https://answers.unity.com/questions/260100/instantiate-as-a-child-of-the-parent.html
            newInstance.GetComponent<InventorySlot>().StoreInformation(types[i], sprites[i]);
            newInstance.GetComponent<InventorySlot>().AddItem(sprites[i]);
        }

    }
}
