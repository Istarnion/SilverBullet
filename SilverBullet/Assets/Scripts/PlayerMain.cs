using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {

	public bool hasBullet = false;
	public bool hasGun = false;
    private int health = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            GameObject.FindWithTag("MASTER").GetComponent<Master>().EndGame(false);
        }
    }

	public void BulletSpent(bool werewolfKilled)
	{
        hasBullet = false;
		if(werewolfKilled) {
            GameObject.FindWithTag("MASTER").GetComponent<Master>().EndGame(true);
		}
		else
		{
            Debug.Log("You're screwed!");
		}
	}
}
