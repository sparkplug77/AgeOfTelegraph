using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_Button : MonoBehaviour {

    public GUISkin mySkin;
    public Transform panel;
    bool menuEnabled;
    bool instructionEnabled;

    void Start()
    {
        menuEnabled = true;
        instructionEnabled = false;
    }

    void OnGUI()
    {

        mySkin.box.fontSize = 50;
        mySkin.box.fontStyle = FontStyle.Bold;
        mySkin.button.fontSize = 30;
        GUI.skin = mySkin;
        if (menuEnabled)
        {

            panel.gameObject.SetActive(false);

            GUI.Box(new Rect((Screen.width >> 1) - 200, (Screen.height >> 1) - 200, 400, 400), "The TeleGraph");


            if (GUI.Button(new Rect((Screen.width >> 1) - 60, (Screen.height >> 1) - 75, 120, 60), "Start"))
            {
                SceneManager.LoadScene(1);
            }
            if (GUI.Button(new Rect((Screen.width >> 1) - 100, (Screen.height >> 1) + 0, 200, 60), "Instructions"))
            {
                menuEnabled = false;
            }
            if (GUI.Button(new Rect((Screen.width >> 1) - 60, (Screen.height >> 1) + 75, 120, 60), "Quit"))
            {
                Application.Quit();
            }
        }
        if (!menuEnabled)
        {
            panel.gameObject.SetActive(true);
            if (GUI.Button(new Rect(25, Screen.height - 75, 120, 60), "Back"))
            {
                instructionEnabled = true;
            }
        }

        if (instructionEnabled)
        {
            menuEnabled = true;
            instructionEnabled = false;
        }
    }
}
