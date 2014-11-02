using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour
{

	public GameObject obj;
    public GUIText hudText;

	void OnTriggerStay(Collider c)
	{
        if(c.tag == "gunPickup")
        {
            hudText.text = "Press 'E' to pick up gun";
            if (Input.GetButton("Activate"))
            {
                Pickup(true);
                Destroy(c.gameObject);
            }
        }
        else if (c.tag == "bulletPickup")
        {
            hudText.text = "Press 'E' to pick up silver bullet";
            if (Input.GetButton("Activate"))
            {
                Pickup(false);
                Destroy(c.gameObject);
            }
        }
        else
        {
            //hudText.text = "";
        }
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "gunPickup")
        {
            hudText.text = "Press 'E' to pick up gun";
        }
        else if (c.tag == "bulletPickup")
        {
            hudText.text = "Press 'E' to pick up silver bullet";
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "gunPickup")
        {
            hudText.text = "";
        }
        else if (c.tag == "bulletPickup")
        {
            hudText.text = "";
        }
    }
	
	private void Pickup(bool gun)
	{
        hudText.text = "";
		if(gun)
		{
			GameObject pickupable = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
			GameObject hand = GameObject.FindWithTag("hand");
			pickupable.transform.parent = hand.transform;
			pickupable.transform.position = hand.transform.position;
			pickupable.transform.rotation = hand.transform.rotation;
		}
		else
		{
			GameObject.FindWithTag("Player").GetComponent<PlayerMain>().hasBullet = true;
		}
	}
}
