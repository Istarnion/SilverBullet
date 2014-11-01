using UnityEngine;
using System.Collections;
using Pathfinding;

public class WerewolfAI : MonoBehaviour
{

	public float speed = 5.0f;

	GameObject player;
	Seeker seeker;
	Path pathToPlayer;
	CharacterController cc;
	int currWaypoint  = 0;
	Vector3 lastPlayerPos;
	bool seeking = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		cc = GetComponent<CharacterController>();
		seeker = GetComponent<Seeker>();
	}

	public void OnPathComplete(Path p) {
		if(!p.error) 
		{
			pathToPlayer = p;
			currWaypoint = 0;
			lastPlayerPos = player.transform.position;
		}
		else {
			Debug.Log("Failed to find path to player");
		}
		seeking = false;
	}

	void FixedUpdate() {
		if(!seeking && (lastPlayerPos == Vector3.zero || Vector3.Distance(player.transform.position, lastPlayerPos) > 2))
		{
			seeker.StartPath(transform.position, player.transform.position, OnPathComplete);
			seeking = true;
		}

		if(pathToPlayer != null) {
			if(currWaypoint >= pathToPlayer.vectorPath.Count-1)
			{
				// Handle end of path, though this should rarely happen, as the end is inside the player.
			}
			else
			{
				Vector3 dir = pathToPlayer.vectorPath[currWaypoint] - transform.position;
				dir.Normalize();
				cc.Move(dir * speed * Time.deltaTime);
				if(Vector3.Distance(transform.position, pathToPlayer.vectorPath[currWaypoint+1]) < 2f)
				{
					currWaypoint++;
				}
 			}
		}
	}
}
