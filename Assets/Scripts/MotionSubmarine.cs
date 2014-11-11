using UnityEngine;
using System.Collections;

public class MotionSubmarine : MonoBehaviour {

	public float maxSpeed = 100f;
	public KeyCode up, down;

	private Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		Debug.Log ("Initialized!");
	}

	// Update is called once per frame
	void Update () {

//		moveDirection = new Vector2(0, Input.GetAxis("Vertical"));
//		moveDirection = transform.TransformDirection(moveDirection);
//		moveDirection *= maxSpeed;
//		
//		if (Input.GetKeyDown (up) || Input.GetKeyDown (down)) {
//			rigidbody2D.velocity = moveDirection;
//		}
		float move = Input.GetAxis ("Vertical");

		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move * maxSpeed);
	}
	
}
