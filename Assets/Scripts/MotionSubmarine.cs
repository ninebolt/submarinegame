using UnityEngine;
using System.Collections;

public class MotionSubmarine : MonoBehaviour {
	public HealthBar HealthBar;
	private static readonly float tilt = 4f;
	public static readonly float cooldown;
	public Vector3 orientation;
	public float maxSpeed;
	public float health;
	public Vector3 healthBarOffset;
	public static readonly float upperLimit = 2.3f;
	public static readonly float lowerLimit = -2.75f;
	public GUIText announcement;
	public bool gameover;
	public float hitstun;

	// Use this for initialization
	public void Start () {
		maxSpeed = 5f * SubmarineGame.gameTempo * SubmarineGame.subSpeed;
		orientation = transform.rotation.eulerAngles;
		health = SubmarineGame.maxHealth;
	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate() {
		if(transform.position.y >= upperLimit) {
			Vector3 newPosition = new Vector3(transform.position.x, upperLimit, transform.position.z);
			transform.position = newPosition;
		}
		if(transform.position.y <= lowerLimit) {
			Vector3 newPosition = new Vector3(transform.position.x, lowerLimit, transform.position.z);
			transform.position = newPosition;
		}

		if(health <= 0) {
			Time.timeScale = 0;
		}
	}

	public void MoveUp() {
		if(hitstun == 0f) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, maxSpeed);
		}
	}
	
	public void MoveDown() {
		if(hitstun == 0f) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, -maxSpeed);
		}
	}
	
	public void Stop() {
		rigidbody2D.velocity = new Vector2 (0f, 0f);
	}

	public void Rotate() {
		rigidbody2D.rotation = tilt * rigidbody2D.velocity.y;

	}

	void OnCollisionEnter2D (Collision2D c) {
//		Torpedo s = c.gameObject.GetComponent<Torpedo>();
//		health = health - c.gameObject.GetComponent<Torpedo>().getDamage ();
//		Destroy (c.gameObject);
//
//		Debug.Log ("New Health is: " + health);
	}

	public void healthUpdate () {
		if (health <= 0) {
			announcement.text = "You win!";
			announcement.material.color = Color.white;
		}
	}
}