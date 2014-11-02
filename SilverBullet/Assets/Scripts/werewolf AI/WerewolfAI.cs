using UnityEngine;
using System.Collections;

public class WerewolfAI : MonoBehaviour
{

	public float speed = 5.0f;

	GameObject player;
	CharacterController cc;
    NavMeshAgent nma;

    wwStateMachine sm;

    public Transform[] patrolPoints;

	void Start () {
		player = GameObject.FindWithTag("Player");
		cc = GetComponent<CharacterController>();
        nma = GetComponent<NavMeshAgent>();

        sm = new wwStateMachine(null);
        sm.ChangeState(new WerewolfPatrol(sm, this));
	}

    void Update()
    {
        sm.Update();
    }

	public CharacterController GetCC()
    {
        return cc;
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    public NavMeshAgent GetNMA()
    {
        return nma;
    }
}
