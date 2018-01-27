using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour {
    PlayerMovement player;
    NavMeshAgent navMesh;
	// Use this for initialization
	void Start () {
        navMesh = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        navMesh.SetDestination(player.transform.position);
        if (!player.gameObject.activeInHierarchy)
            gameObject.SetActive(false);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // gameover screen
        }
    }
}
