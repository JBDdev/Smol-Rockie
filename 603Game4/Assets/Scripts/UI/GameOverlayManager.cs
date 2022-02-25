using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverlayManager : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private Text rCHNumber;
    [SerializeField] private Text rCNumber;
    [SerializeField] private Text pNumber;

    private GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rCHNumber.text = gM.DisplayRocksHeld();
        rCNumber.text = gM.DisplayRockCurrency();
        pNumber.text = gM.DisplayPremiium();
    }
}
