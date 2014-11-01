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
		Vector3 targetDirection = new Vector3(Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
		targetDirection.Normalize();
		targetDirection *= Time.deltaTime;
		cc.Move(targetDirection * speed);
	}
}
