using UnityEngine;
using System.Collections;

public class MotionSub_R : MotionSubmarine {
	public Burst burst;
	private Vector2 offset;
	new private float cooldown;
	public Transform torpedo_R_Light;
	public Transform torpedo_R_Medium;
	public Transform torpedo_R_Heavy;
	
	new void Start () {
		maxSpeed = 5f * SubmarineGame.gameTempo * SubmarineGame.subSpeed;
		offset = new Vector2 (-0.8f, 0f);
		cooldown = 0f;
		health = SubmarineGame.maxHealth;
		healthBarOffset = new Vector3(0f, transform.localScale.y * 1.5f, 0f);
		gameover = false;
		hitstun = 0f;
	}

	// Update is called once per frame
	void Update () {
		HealthBar.transform.position = transform.position + healthBarOffset;
		healthUpdate ();
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);
		hitstun = Mathf.Max (0f, hitstun - Time.deltaTime);

		float move = Input.GetAxis ("VerticalAxis_2");
		if((move > 0 && transform.position.y < upperLimit) || (move < 0 && transform.position.y > lowerLimit)) {
			if(hitstun == 0f) {	
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move * maxSpeed);
			}
		}
		Rotate ();

		if(Input.GetKey (KeyCode.UpArrow)) {
			MoveUp ();
			Rotate ();
		}
		else if(Input.GetKey (KeyCode.DownArrow)) {
			MoveDown ();
			Rotate ();
		}
		else if(move == 0) {
			Stop ();
		}
		
		if(cooldown == 0f && hitstun == 0f) {
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation = new Vector3(orientation.x,orientation.y,orientation.z);

			if(Input.GetKeyDown (KeyCode.Joystick2Button0) || Input.GetKeyDown (KeyCode.Alpha7)){
				if(burst.fireLight ()){
					Transform torpedo = (Transform)Instantiate (torpedo_R_Light, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
					burst.fireLight ();
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(-LightTorpedo.lightSpeed, 0f);//rigidbody2D.velocity.y * 0.25f);
				}
			}
			else if(Input.GetKeyDown (KeyCode.Joystick2Button1) || Input.GetKeyDown ( KeyCode.Alpha8)){
				if(burst.fireMedium ()){
					Transform torpedo = (Transform)Instantiate (torpedo_R_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
					burst.fireMedium ();
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(-MediumTorpedo.mediumSpeed, 0f);
				}
			}
			else if(Input.GetKeyDown (KeyCode.Joystick2Button3) || Input.GetKeyDown ( KeyCode.Alpha9)){
				if(burst.fireHeavy ()){
					Transform torpedo = (Transform)Instantiate (torpedo_R_Heavy, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
					burst.fireHeavy ();
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(-HeavyTorpedo.heavySpeed, 0f);
				}
			}
		}
	}

	new public void Rotate() {
		rigidbody2D.rotation = -2f * rigidbody2D.velocity.y;
	}

	void OnCollisionEnter2D (Collision2D c) {
		Torpedo s = c.gameObject.GetComponent<Torpedo>();
		health = health - s.getDamage ();
		HealthBar.AddDamage ((int)s.getDamage ());
		hitstun = s.stun;
		Destroy (c.gameObject);
	}

	new void healthUpdate () {
		if (health <= 0) {
			gameover = true;
			announcement.text = "Red sub wins...\n\nPress enter to\nstart a new game";
			announcement.material.color = Color.black;
		}
	}
}