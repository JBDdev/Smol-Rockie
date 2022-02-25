// Code provided by: PaulaOstupe - https://answers.unity.com/questions/1498087/capture-screenshots-and-save-them-in-folder.html

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Screenshot : MonoBehaviour
{
    [SerializeField] GameObject uI;

    public void onScreenshot()
    {
        uI.GetComponent<UIManager>().ButtonPress("cameraStart"); // Doesn't work
        Debug.Log("Clicked Screenshot: " + Application.dataPath + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss" + ".png"));
        ScreenCapture.CaptureScreenshot(Application.dataPath + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
        uI.GetComponent<UIManager>().ButtonPress("cameraEnd");
    }
}
