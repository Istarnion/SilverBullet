using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {

	public bool hasBullet = false;
	public bool hasGun = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BulletSpent(bool werewolfKilled)
	{
        hasBullet = false;
		if(!werewolfKilled) {
			Debug.Log("You're screwed!");
		}
		else
		{
			Debug.Log("You did it!");
		}
	}
}
