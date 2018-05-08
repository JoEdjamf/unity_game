using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float speed;
	private float verticalVelocity; 
	private float gravity;

	private CharacterController controller;
	private Vector3 moveVector;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = Vector3.zero;

		if (controller.isGrounded) {
			verticalVelocity = -0.5f;
		} else
		{
			verticalVelocity -= gravity * Time.deltaTime;
		}

		//	X - Left and Right
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
		//	Y - Up and Down
		moveVector.y = verticalVelocity;
		//	Z - Forward and Backward
		moveVector.z = speed;

		controller.Move (moveVector * Time.deltaTime);

	}
}
