using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

    private NavMeshAgent agent;
    Transform player;

	// Use this for initialization
	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination (player.position);
    	}
}
