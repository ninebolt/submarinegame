using UnityEngine;
using System.Collections;

public class MotionSubmarine : MonoBehaviour {

	public float maxSpeed = 10f;
	public KeyCode up, down;

	// Use this for initialization
	public void Start () {
		Debug.Log ("Initialized!");
	}

	// Update is called once per frame
	void Update () {

	}

	public void MoveUp() {
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, maxSpeed);
	}
	
	public void MoveDown() {
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -maxSpeed);
	}
	
	public void Stop() {
		rigidbody2D.velocity = new Vector2 (0f, 0f);
	}
}