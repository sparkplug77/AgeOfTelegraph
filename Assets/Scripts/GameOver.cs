using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GUISkin mySkin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.skin = mySkin;

        if (GUI.Button(new Rect(25, Screen.height - 75, 120, 60), "Menu"))
        {
            SceneManager.LoadScene(0);
        }
        if (GUI.Button(new Rect(Screen.width - 150, Screen.height - 75, 120, 60), "Quit"))
        {
            Application.Quit();
        }
    }
}
