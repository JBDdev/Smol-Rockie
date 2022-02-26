// Code provided by: PaulaOstupe - https://answers.unity.com/questions/1498087/capture-screenshots-and-save-them-in-folder.html
// Microsoft Documentation - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-create-a-file-or-folder
// https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-choose-folders-with-the-windows-forms-folderbrowserdialog-component?view=netframeworkdesktop-4.8
// 

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    [SerializeField] GameObject uI;
    [SerializeField] InputField userPath;

    private string gamePath; // Game folder
    private string screenshotsPath; // Screenshots folder
    private string defaultPath; // Default folders

    public void Start()
    {
        // Set default paths
        gamePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Smol Rockie";
        screenshotsPath = gamePath + Path.DirectorySeparatorChar + "Screenshots";
        defaultPath = screenshotsPath;

        userPath.text = defaultPath;
    }

    /// <summary>
    /// Takes a screenshot of the game and saves to preset folder location
    /// </summary>
    public void onScreenshot()
    {
        uI.GetComponent<UIManager>().ButtonPress("cameraStart"); // Doesn't work


        // If the user did not set location already
        if (defaultPath == screenshotsPath || userPath.text == null)
        {
            // Check if either default folder exists already
            if (!Directory.Exists(defaultPath))
            {
                // Create default
                Directory.CreateDirectory(defaultPath);
                userPath.text = defaultPath;
            }

            screenshotsPath = userPath.text;
            Debug.Log("Default: " + screenshotsPath + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
            ScreenCapture.CaptureScreenshot(screenshotsPath + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
        }
        // If exists, take screenshot
        else
        {
            screenshotsPath = userPath.text;
            Debug.Log("Changed:" + screenshotsPath + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
            ScreenCapture.CaptureScreenshot(screenshotsPath + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
        }

        uI.GetComponent<UIManager>().ButtonPress("cameraEnd");
    }

    /// <summary>
    /// Change the filepath for screenshots
    /// </summary>
    public void onSetLocation()
    {
        string savePath = EditorUtility.OpenFolderPanel("Open Folder", "", "");

        if (savePath != null)
        {
            screenshotsPath = savePath;
            userPath.text = screenshotsPath;
        }
    }
}
