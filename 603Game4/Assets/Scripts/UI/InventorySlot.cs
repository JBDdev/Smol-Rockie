using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private string itemType;
    [SerializeField] private Sprite itemImage;

    public void StoreInformation(string type, Sprite image)
    {
        itemType = type;
        itemImage = image;
    }

    public void AddItem(Sprite image)
    {
        itemIcon.sprite = image;
        itemIcon.color = new Color(itemIcon.color.r, itemIcon.color.g, itemIcon.color.b, 1.0f);
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
