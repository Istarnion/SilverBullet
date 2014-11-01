using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{

	public float speed = 4.0f;
	CharacterController cc;

	// Use this for initialization
	void Start ()
	{
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 targetDirection = Camera.main.transform.forward;
		targetDirection *= Input.GetAxis("Vertical");
		targetDirection += Camera.main.transform.right * Input.GetAxis("Horizontal");
		targetDirection.Normalize();
		targetDirection *= Time.deltaTime;
		cc.Move(targetDirection * speed);
	}
}
