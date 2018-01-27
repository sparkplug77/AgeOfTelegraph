using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour {

    GameObject Player;
    GameObject morse;
    Transform morseCanvas;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        morse = GameObject.FindGameObjectWithTag("MorseCanvas");
        morseCanvas = morse.transform.Find("Canvas");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && !morseCanvas.gameObject.activeInHierarchy)
        {
            morseCanvas.gameObject.SetActive(true);
            Player.SetActive(false);
        }

    }

}
