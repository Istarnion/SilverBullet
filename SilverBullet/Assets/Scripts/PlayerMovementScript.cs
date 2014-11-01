using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	CharacterController cc;

	// Use this for initialization
	void Start ()
	{
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 targetDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetDirection = transform.TransformDirection(targetDirection);
		targetDirection.Normalize();
		targetDirection *= speed;
		if(cc.isGrounded && Input.GetButtonDown("Jump"))
		{
			targetDirection.y = jumpSpeed;
		}
		targetDirection.y -= gravity * Time.fixedDeltaTime;

		cc.Move(targetDirection * Time.fixedDeltaTime);
	}
}
