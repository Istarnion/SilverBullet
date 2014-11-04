using UnityEngine;
using System.Collections;

public class werewolfAnim : MonoBehaviour {

    NavMeshAgent nma;
    Transform player;
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
        player = GameObject.FindWithTag("Player").transform;
        anim["walk"].speed = 2.5f;
	}
	
    public void Die()
    {
        currState = AnimState.DIE;
        anim.Play("die");
        nma.Stop();
    }

	// Update is called once per frame
	void Update () {
        if(currState != AnimState.DIE)
        {
            if (Vector3.Distance(transform.position, player.position) < 3f)
            {
                if(currState != AnimState.ATTACK)
                {
                    currState = AnimState.ATTACK;
                    anim.Play("strike");
                    GameObject.FindWithTag("MASTER").GetComponent<Master>().EndGame(false);
                }
            }
            else
            {
                if (nma.speed < 0.2f && currState != AnimState.IDLE)
                {
                    anim.Play("idle");
                    currState = AnimState.IDLE;
                }
                else if (nma.speed >= 0.2f && currState != AnimState.WALK)
                {
                    anim.Play("walk");
                    currState = AnimState.WALK;
                }
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y - (2 * Time.deltaTime), transform.position.z), .2f);
        }
	}
}
