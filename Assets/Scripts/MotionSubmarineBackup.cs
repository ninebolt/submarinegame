using UnityEngine;
using System.Collections;

public class MotionSubmarineBackup : MonoBehaviour {
	
	public float maxSpeed = 10f;
	public KeyCode up, down;
	public GameObject rightSubmarine;
	public GameObject leftSubmarine;
	
	private Vector2 moveDirection;
	
	// Use this for initialization
	public void Start () {
		Debug.Log ("Initialized!");
		rightSubmarine = GameObject.Find ("Submarine_R");
		leftSubmarine = GameObject.Find ("Submarine_L");
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