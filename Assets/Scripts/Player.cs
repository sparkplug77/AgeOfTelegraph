using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameObject morse;
    Transform morseCanvas;
    Text morseText;
    public Text messagesText;
    public Text gamePlayText;
    public Text textTimer;

    public AudioClip dashAudio;
    public AudioClip dotAudio;
    public AudioClip errorAudio;

    AudioSource audioSource;

    Transform morsePanel;
    Transform cheatSheetPanel;
    Button cheatSheetButton;


    bool isDot;
    bool isHypen;
    bool isComplete;
    bool displayCheatSheet;
    bool startGame;

    float timer;

    string message;

    void Awake()
    {
        message = "Type in 'EMERGENCY SOS' using the morse code. Feel free to use the cheat sheet to check the morse code for all the alphabets." + "\r\n" + "Press 'Enter' to start";
    }

	// Use this for initialization
	void Start ()
    {
        isDot = false;
        isHypen = false;
        isComplete = false;
        displayCheatSheet = false;
        startGame = false;
        morse = GameObject.FindGameObjectWithTag("MorseCanvas");
        morseCanvas = morse.transform.Find("Canvas");
        morseText = morseCanvas.transform.Find("Panel").transform.Find("MorseText").GetComponent<Text>();
        audioSource = morse.GetComponent<AudioSource>();

        morsePanel = morseCanvas.transform.Find("Panel");
        morsePanel.gameObject.SetActive(true);

        cheatSheetPanel = morseCanvas.transform.Find("MCCheatSheet_Panel");
        cheatSheetPanel.gameObject.SetActive(false);

        cheatSheetButton = morseCanvas.transform.Find("MCCheatSheet_Button").GetComponent<Button>();
        morseCanvas.gameObject.SetActive(false);

        gamePlayText.text = message;

	}
    void OnGUI()
    {
        morseText.text = GUI.TextField(new Rect(0, 0, 0, 0), morseText.text, 7);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Return))
            startGame = true;

        if (morsePanel.gameObject.activeInHierarchy && startGame)
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
        if (!displayCheatSheet)
            cheatSheetButton.onClick.AddListener(DisplayCheatSheet);
        else
            cheatSheetButton.onClick.AddListener(DisplayMorsePanel);

        if (messagesText.text == "EMERGENCY SOS")
        {
            // quit screen
            SceneManager.LoadScene(1);
        }
        else if (messagesText.text.Length > 13)
        {
            // quit screen
            SceneManager.LoadScene(2);
        }
    }

    public void Tap()
    {
        if (timer < 2.0f && !isDot)
        {
            isDot = true;
            audioSource.clip = dotAudio;
            morseText.text += ".";
        }
        if (timer > 2.0f && timer < 3.0f && !isHypen)
        {
            isHypen = true;
            audioSource.clip = dashAudio;
            morseText.text += "-";
        }

        if (morseText.text.Length > 7)
        {
            // error audio
            audioSource.clip = errorAudio;
            morseText.text = "";
        }
        audioSource.Play();
        timer = 0;
        isDot = false;
        isHypen = false;
    }

    void DisplayCheatSheet()
    {
        morsePanel.gameObject.SetActive(false);
        cheatSheetPanel.gameObject.SetActive(true);
        cheatSheetButton.GetComponentInChildren<Text>().text = "Back";
        //morseCode.DisplayDictionary();
        displayCheatSheet = true;
    }

    void DisplayMorsePanel()
    {
        morsePanel.gameObject.SetActive(true);
        cheatSheetPanel.gameObject.SetActive(false);
        cheatSheetButton.GetComponentInChildren<Text>().text = "MC Cheat Sheet";
        displayCheatSheet = false;
    }
}
