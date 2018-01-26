using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morse : MonoBehaviour
{
    static Dictionary<string, char> morseCodeDictionary;

	// Use this for initialization
	void Start ()
    {
        InitializeMCDictionary();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void InitializeMCDictionary()
    {
        morseCodeDictionary = new Dictionary<string, char>()
        {
            {".-", 'A'},
            {"-...", 'B'},
            {"-.-.", 'C'},
            {"-..", 'D'},
            {".", 'E'},
            {"..-.", 'F'},
            {"--.", 'G'},
            {"....", 'H'},
            {"..", 'I'},
            {".---", 'J'},
            {"-.-" , 'K'},
            {".-..", 'L'},
            {"--" , 'M'},
            {"-.", 'N'},
            {"---", 'O'},
            {".--.", 'P'},
            {"--.-", 'Q'},
            {".-." , 'R'},
            {"...", 'S'},
            {"-", 'T'},
            {"..-", 'U'},
            {"...-", 'V'},
            {".--", 'W'},
            {"-..-", 'X'},
            {"-.--", 'Y'},
            {"--..", 'Z'},
            {".----", '1'},
            {"..---", '2'},
            {"...--", '3'},
            {"....-", '4'},
            {".....", '5'},
            {"-....", '6'},
            {"--...", '7'},
            {"---..", '8'},
            {"----.", '9'},
            {"-----", '0'},
        };
    }

    public string MorseCodeDecoder(string input)
    {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        if (morseCodeDictionary.ContainsKey(input))
        {
            stringBuilder.Append(morseCodeDictionary[input]);
        }

        else
        {
            string errorString = "Error! Try Again!";
            return errorString;
        }
        return stringBuilder.ToString();
    }
}
