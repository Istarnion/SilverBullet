using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	private PlayerMain pm;

	void Start()
	{
		pm = GameObject.FindWithTag("Player").GetComponent<PlayerMain>();
	}

	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position, transform.forward);
		if(Input.GetButtonDown("Fire1")) {
			if(!pm.hasBullet)
			{
				Debug.Log("Out of bullets, out of luck");
			}
			else
			{
				Fire();
			}
		}
	}

	private void Fire()
	{
        Debug.Log("BANG!");
		RaycastHit hitInfo;
		if(Physics.Raycast(transform.position, transform.forward, out hitInfo, Mathf.Infinity))
		{
            if(hitInfo.collider.tag == "werewolf")
            {
                hitInfo.collider.gameObject.GetComponent<werewolfAnim>().Die();
                pm.BulletSpent(true);
            }
            else
            {
                pm.BulletSpent(false);
            }
		}
	}
}
