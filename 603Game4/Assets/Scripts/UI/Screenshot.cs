// Code provided by: PaulaOstupe - https://answers.unity.com/questions/1498087/capture-screenshots-and-save-them-in-folder.html
// Microsoft Documentation - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-create-a-file-or-folder

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Screenshot : MonoBehaviour
{
    [SerializeField] GameObject uI;

    private String gamePath;
    private String screenshotsPath;

    public void onScreenshot()
    {
        uI.GetComponent<UIManager>().ButtonPress("cameraStart"); // Doesn't work

        // Set paths
        gamePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Smol Rockie";
        screenshotsPath = gamePath + Path.DirectorySeparatorChar + "Screenshots";

        // Check if either folder exists already
        if (!Directory.Exists(gamePath))
        {
            if (!Directory.Exists(screenshotsPath))
            {
                // If not, create
                Directory.CreateDirectory(gamePath);
                Directory.CreateDirectory(screenshotsPath);

            }
        }
        // IF exists, take screenshot
        else
        {
            Debug.Log(screenshotsPath + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
            ScreenCapture.CaptureScreenshot(screenshotsPath + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
        }

        uI.GetComponent<UIManager>().ButtonPress("cameraEnd");
    }
}
