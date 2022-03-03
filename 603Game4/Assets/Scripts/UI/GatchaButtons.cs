using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatchaButtons : MonoBehaviour
{
    [SerializeField] private GameObject gatchaManager;

    public void OnClick()
    {
        gatchaManager.GetComponent<GachaScript>().Pull();
    }
}
