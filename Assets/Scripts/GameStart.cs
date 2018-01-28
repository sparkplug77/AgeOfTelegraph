using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    RawImage splashScreen;
    RawImage gameScreen;
    GUI_Button guiButton;

    Color c;

    float timer;
	// Use this for initialization
	void Start ()
    {
        guiButton = GetComponent<GUI_Button>();
        guiButton.enabled = false;
        splashScreen = gameObject.transform.Find("SplashScreen").GetComponent<RawImage>();
        gameScreen = gameObject.transform.Find("GameScreen").GetComponent<RawImage>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > 5.0f)
        {
            splashScreen.gameObject.SetActive(false);
            gameScreen.gameObject.SetActive(true);
        }

        if (gameScreen.gameObject.activeInHierarchy)
        {
            guiButton.enabled = true;
            this.enabled = false;
        }
	}
}
