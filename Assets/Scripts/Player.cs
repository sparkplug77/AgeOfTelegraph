using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public Morse morseCode;
    public Text morseText;
    public Text messagesText;
    public Text textTimer;


    bool isDot;
    bool isHypen;
    bool isComplete;

    float timer;


	// Use this for initialization
	void Start ()
    {
        isDot = false;
        isHypen = false;
        isComplete = false;
        

	}
    void OnGUI()
    {
        morseText.text = GUI.TextField(new Rect(0, 0, 0, 0), morseText.text, 5);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        textTimer.text = timer.ToString("f0");
        if ((int)timer == 5/* && timer < 7.0f*/)
        {
            isComplete = true;
            messagesText.text += Morse.MorseCodeDecoder(morseText.text);
            timer = 0;
            isComplete = false;
            morseText.text = "";
        }
    }

    public void Tap()
    {
        if (timer < 1.0f && !isDot)
        {
            isDot = true;
            morseText.text += ".";
        }
        if (timer > 2.0f && timer < 3.0f && !isHypen)
        {
            isHypen = true;
            morseText.text += "-";
        }

        if (morseText.text.Length > 5)
        {
            // error audio
            morseText.text = "";
        }
        timer = 0;
        isDot = false;
        isHypen = false;
    }
}
