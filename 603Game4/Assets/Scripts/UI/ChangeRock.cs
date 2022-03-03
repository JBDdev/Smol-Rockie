using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRock : MonoBehaviour
{
    [SerializeField] private GameObject parentRock;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private GameObject inventorySlot;
    [SerializeField] private GameObject collection;

    private void Start()
    {
        parentRock = GameObject.Find("Rock");
        collection = GameObject.Find("GameData");
    }

    public void OnClick()
    {

    }
}
