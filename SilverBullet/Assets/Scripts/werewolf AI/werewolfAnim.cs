using UnityEngine;
using System.Collections;

public class werewolfAnim : MonoBehaviour {

    NavMeshAgent nma;
    public Animation anim;

    private enum AnimState
    {
        IDLE,
        WALK,
        ATTACK,
        HOWL,
        DIE
    }

    AnimState currState = AnimState.IDLE;

	// Use this for initialization
	void Start () {
        nma = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(nma.speed < 0.2f && currState != AnimState.IDLE)
        {
            anim.Play("idle");
            currState = AnimState.IDLE;
        }
        else if(nma.speed >= 0.2f && currState != AnimState.WALK)
        {
            anim.Play("walk");
            currState = AnimState.WALK;
        }
	}
}
