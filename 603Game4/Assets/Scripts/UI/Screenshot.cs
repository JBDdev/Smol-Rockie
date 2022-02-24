// Code provided by: PaulaOstupe - https://answers.unity.com/questions/1498087/capture-screenshots-and-save-them-in-folder.html

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    public void onScreenshot()
    {
        Debug.Log("Clicked Screenshot");
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/screenshots/" + DateTime.Now.ToString("yyy-MM-dd HH-mm-ss") + ".png");
        //UnityEditor.AssetDatabase.Refresh();
    }
}
