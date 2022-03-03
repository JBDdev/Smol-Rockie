using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCustomize : MonoBehaviour
{
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject inventorySlot;

    private SpriteRenderer hat;
    private SpriteRenderer face;
    private SpriteRenderer neck;

    public void Start()
    {
        rockPrefab = GameObject.Find("Rock");

        hat = GameObject.Find("Hat").GetComponent<SpriteRenderer>();
        face = GameObject.Find("EyeWear").GetComponent<SpriteRenderer>();
        neck = GameObject.Find("NeckWear").GetComponent<SpriteRenderer>();

    }

    public void OnClick()
    {
        if (inventorySlot.GetComponent<InventorySlot>().ItemType == "Hat")
        {
            hat.sprite = inventorySlot.GetComponent<InventorySlot>().ItemImage;
        }
        else if (inventorySlot.GetComponent<InventorySlot>().ItemType == "Eyes")
        {
            face.sprite = inventorySlot.GetComponent<InventorySlot>().ItemImage;
        }
        else if (inventorySlot.GetComponent <InventorySlot>().ItemType == "Neck")
        {
            neck.sprite = inventorySlot.GetComponent<InventorySlot>().ItemImage;
        }
    }
}
