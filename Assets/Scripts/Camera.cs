using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Transform Player;
    Vector3 offset;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = Player.position - transform.position;

		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraPos = Player.position - offset;
        transform.position = Vector3.Lerp(transform.position, cameraPos, 10 * Time.deltaTime);
	}
}
