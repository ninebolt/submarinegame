using UnityEngine;
using System.Collections;

public class MotionSubmarine : MonoBehaviour {
	public HealthBar HealthBar;
	private static readonly float tilt = 4f;
	public float cooldown;
	public float EMPCooldown;
	public float NukeCooldown;
	public static readonly float EMPCooldownTime = 0.25f;
	public static readonly float NukeCooldownTime = 0.25f;
	public Vector3 orientation;
	public float maxSpeed;
	public float health;
	public Vector3 healthBarOffset;
	public static readonly float upperLimit = 2.3f;
	public static readonly float lowerLimit = -2.0f;
	public GUIText announcement;
	public bool gameover;
	public float hitstun;
	public readonly float torpedoSlide = 0.2f;
	public ParticleSystem empParticle;

	// Use this for initialization
	public void Start () {
		maxSpeed = 5f * SubmarineGame.gameTempo * SubmarineGame.subSpeed;
		orientation = transform.rotation.eulerAngles;
		health = SubmarineGame.maxHealth;
		cooldown = 0f;
		EMPCooldown = 0f;
		NukeCooldown = 0f;
	}

	void Update () {
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);
		EMPCooldown = Mathf.Max (0f, EMPCooldown - Time.deltaTime);
		NukeCooldown = Mathf.Max (0f, NukeCooldown - Time.deltaTime);
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
		Torpedo s = c.gameObject.GetComponent<Torpedo>();
		switch(s.type){
		case 0:
			takeDamage (s);
			s.PlaySound ();
			break;
		case 1:
			if(EMPCooldown == 0f){
				takeDamage (s);
				EMPCooldown = EMPCooldownTime;
				s.PlaySound ();
				rigidbody2D.velocity = new Vector2(0f, 0f);
			}
			break;
		case 2:
			if(NukeCooldown == 0f){
				takeDamage (s);
				NukeCooldown = NukeCooldownTime;
				s.PlaySound ();
			}
			break;
		}
		Destroy (c.gameObject);
	}

	void takeDamage(Torpedo s){
		health = health - s.getDamage ();
		HealthBar.AddDamage ((int)s.getDamage ());
		hitstun = s.stun;
	}

	public void healthUpdate () {
		if (health <= 0) {
			announcement.text = "You win!";
			announcement.material.color = Color.white;
		}
	}
}