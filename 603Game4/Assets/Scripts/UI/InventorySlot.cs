using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private string itemType;
    [SerializeField] private Sprite itemImage;

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


    public void StoreInformation(string name, string type, Sprite image)
    {
        itemType = type;
        itemImage = image;
    }

    public void AddItem(Sprite image)
    {
        itemIcon.sprite = image;
        itemIcon.preserveAspect = true;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1.0f);
    }

    public void StoreRockInformation(string name, Sprite image)
    {
        itemImage = image;
    }

    public void onSelected()
    {
        DressRock(itemType);
    }

    private void DressRock(string type)
    {
        switch (type)
        {
            //case ""
        }
    }
}
