using UnityEngine;
using System.Collections;

public class PickupScript : MonoBehaviour
{

	public GameObject obj;
    public GUIText guiText;

	void OnTriggerStay(Collider c)
	{
        if(c.tag == "gunPickup")
        {
            guiText.text = "Press 'E' to pick up gun";
            if (Input.GetButtonDown("Activate"))
            {
                Pickup(true);
                Destroy(c.gameObject);
            }
        }
        else if (c.tag == "bulletPickup")
        {
            guiText.text = "Press 'E' to pick up silver bullet";
            if (Input.GetButtonDown("Activate"))
            {
                Pickup(false);
                Destroy(c.gameObject);
            }
        }
        else
        {
            guiText.text = "";
        }
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "gunPickup")
        {
            guiText.text = "Press 'E' to pick up gun";
        }
        else if (c.tag == "bulletPickup")
        {
            guiText.text = "Press 'E' to pick up silver bullet";
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "gunPickup")
        {
            guiText.text = "";
        }
        else if (c.tag == "bulletPickup")
        {
            guiText.text = "";
        }
    }
	
	private void Pickup(bool gun)
	{
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
