using UnityEngine;
using System.Collections;

public class MotionSubmarine : MonoBehaviour {
	private static readonly float tilt = 4f;
	public float maxSpeed;
	public float health;

	// Use this for initialization
	public void Start () {
		//Debug.Log ("Initialized!");
		maxSpeed = 5f;
	}

	// Update is called once per frame
	void Update () {

	}

	public void MoveUp() {
		rigidbody2D.velocity = SubmarineGame.gameTempo * SubmarineGame.subSpeed 
			* new Vector2 (rigidbody2D.velocity.x, maxSpeed);
	}
	
	public void MoveDown() {
		rigidbody2D.velocity = SubmarineGame.gameTempo * SubmarineGame.subSpeed 
			* new Vector2 (rigidbody2D.velocity.x, -maxSpeed);
	}
	
	public void Stop() {
		rigidbody2D.velocity = SubmarineGame.gameTempo * SubmarineGame.subSpeed 
			* new Vector2 (0f, 0f);
	}

	public void Rotate() {
		rigidbody2D.rotation = tilt * rigidbody2D.velocity.y;
	}

	void OnCollisionEnter2D (Collision2D c) {
		Debug.Log ("Hit!");

		Torpedo s = c.gameObject.GetComponent<Torpedo>();
		health = health - s.getDamage ();
		Destroy (c.gameObject);

		Debug.Log ("New Health is: " + health);
	}
}