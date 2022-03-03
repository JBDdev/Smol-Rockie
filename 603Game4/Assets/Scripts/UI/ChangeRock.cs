using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRock : MonoBehaviour
{
    [SerializeField] private GameObject parentRock;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject inventorySlot;
    [SerializeField] private GameObject collection;
    [SerializeField] private GameObject gameManager;

    private void Start()
    {
        
    }

    public void OnClick()
    {
        parentRock = GameObject.Find("Rockie");
        collection = GameObject.Find("GameData");
        gameManager = GameObject.Find("GameManager");


        collection.GetComponent<Collection>().data.currentRock = inventorySlot.GetComponent<InventorySlot>().Index;
        Destroy(parentRock.transform.GetChild(0).gameObject);
        
        collection.GetComponent<Collection>().UpdateFile();
        gameManager.GetComponent<GameManager>().Invoke("LoadRockie", 0.5f);
    }
}
