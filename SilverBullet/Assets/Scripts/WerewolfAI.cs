using UnityEngine;
using System.Collections;

public class WerewolfAI : MonoBehaviour
{

	public float speed = 5.0f;

	GameObject player;
	CharacterController cc;
    NavMeshAgent nma;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		cc = GetComponent<CharacterController>();
        nma = GetComponent<NavMeshAgent>();
	}

	void FixedUpdate() {
        nma.destination = player.transform.position;
	}
}
