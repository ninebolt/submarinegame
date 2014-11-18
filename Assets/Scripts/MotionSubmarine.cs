using UnityEngine;
using System.Collections;

public class MotionSubmarine : MonoBehaviour {

	public float maxSpeed;
	public ArrayList torpedoes;

	public int health;

	// Use this for initialization
	public void Start () {
		//Debug.Log ("Initialized!");
		maxSpeed = 5f;
		torpedoes = new ArrayList ();
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

	public void Rotate() {
		rigidbody2D.rotation = 2f * rigidbody2D.velocity.y;
	}

	void OnCollisionEnter2D (Collision2D c) {
		Debug.Log ("Hit!");

		Torpedo s = c.gameObject.GetComponent<Torpedo>();
		health = health - s.getDamage ();
		Destroy (c.gameObject);

		Debug.Log ("New Health is: " + health);
	}
}