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
        hat = rockPrefab.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        face = rockPrefab.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
        neck = rockPrefab.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>();
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
