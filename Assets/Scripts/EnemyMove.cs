using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    public GameManager gameManager;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(player.position);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerBady")
        {
            nav.isStopped = true;
            gameManager.EndGame();
        }
    }
}
