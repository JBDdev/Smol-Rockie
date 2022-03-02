using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemImage;

    public void AddItem(string name, Sprite image)
    {
        itemIcon.sprite = image;
    }
}
