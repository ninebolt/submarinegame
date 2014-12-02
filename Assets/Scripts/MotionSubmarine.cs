using UnityEngine;
using System.Collections;

public class MotionSubmarine : MonoBehaviour {
	private static readonly float tilt = 4f;
	public static readonly float cooldown;
	public Vector3 orientation;
	public float maxSpeed;
	public float health;

	public GUIText healthGUI;

	// Use this for initialization
	public void Start () {
		//Debug.Log ("Initialized!");
		maxSpeed = 5f * SubmarineGame.gameTempo * SubmarineGame.subSpeed;
		orientation = transform.rotation.eulerAngles;
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
		rigidbody2D.rotation = tilt * rigidbody2D.velocity.y;
	}

	void OnCollisionEnter2D (Collision2D c) {
		//Torpedo s = c.gameObject.GetComponent<Torpedo>();
		health = health - c.gameObject.GetComponent<Torpedo>().getDamage ();
		Destroy (c.gameObject);

		Debug.Log ("New Health is: " + health);
	}

	public void healthUpdate () {
		if (health <= 0) {
			healthGUI.text = "You lose!";
			healthGUI.material.color = Color.white;
		} else {
			healthGUI.text = health.ToString ();
			
			if (health <= 4) {
				healthGUI.material.color = Color.red;
			}
		}
	}
}