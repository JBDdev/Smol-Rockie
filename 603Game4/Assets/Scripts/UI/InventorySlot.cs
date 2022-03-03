using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private string itemType;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemImage;
    [SerializeField] private int itemIndex;

    //---------PROPERTIES---------
    public string ItemType
    {
        get { return itemType; }
        set { itemType = value; }
    }

    public Sprite ItemImage
    {
        get { return itemImage; }
        set { itemImage = value; }
    }

    public int Index
    {
        get { return itemIndex; }
        set { itemIndex = value; }
    }

    public void StoreInformation(string name, string type, Sprite image, int index)
    {
        itemName = name;
        itemType = type;
        itemImage = image;
        itemIndex = index;
    }

    public void AddItem(Sprite image)
    {
        itemIcon.sprite = image;
        itemIcon.preserveAspect = true;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1.0f);
    }

    public void StoreRockInformation(string name, Sprite image, int index)
    {
        itemName = name;
        itemImage = image;
        itemIndex = index;
    }
}
