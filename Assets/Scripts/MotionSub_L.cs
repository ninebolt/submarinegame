using UnityEngine;
using System.Collections;

public class MotionSub_L : MotionSubmarine {
	public Burst burst;
	private Vector2 offset;
	new private float cooldown;
	public Transform torpedo_L_Light;
	public Transform torpedo_L_Medium;
	public Transform torpedo_L_Heavy;
	
	new void Start () {
		maxSpeed = 5f * SubmarineGame.gameTempo * SubmarineGame.subSpeed;
		offset = new Vector2 (0.8f, 0f);
		cooldown = 0f;
		health = SubmarineGame.maxHealth;
		healthBarOffset = new Vector3(0f, transform.localScale.y * 1.5f, 0f);
		gameover = false;
	}
	
	// Update is called once per frame
	void Update () {
		HealthBar.transform.position = transform.position + healthBarOffset;

		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);

		healthUpdate ();

		float move = Input.GetAxis ("VerticalAxis_1");
		
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move * maxSpeed);
		Rotate ();

		if(Input.GetKey (KeyCode.W)) {
			MoveUp ();
			Rotate ();
		}
		else if(Input.GetKey (KeyCode.S)) {
			MoveDown ();
			Rotate ();
		}
		else if(move == 0) {
			Stop ();
		}

		if(cooldown == 0f) {	
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation = new Vector3(orientation.x,orientation.y,orientation.z+180);

			if(Input.GetKeyDown (KeyCode.Joystick1Button0) || Input.GetKeyDown (KeyCode.Alpha1)) {
				if(burst.fireLight ()){
					Transform torpedo = (Transform)Instantiate (torpedo_L_Light, ((Vector2)transform.position) 
					                                            + offset, Quaternion.Euler (rotation));
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(LightTorpedo.lightSpeed, 0f);//rigidbody2D.velocity.y * 0.25f);
				}
				else{
					Debug.Log (burst.getLightCharges ());
				}
			}
			else if(Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Alpha2)){
				if(burst.fireMedium ()){
					Transform torpedo = (Transform)Instantiate (torpedo_L_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(MediumTorpedo.mediumSpeed, 0f);
				}
			}
			else if(Input.GetKeyDown (KeyCode.Joystick1Button3) || Input.GetKeyDown (KeyCode.Alpha3)){
				if(burst.fireHeavy ()){
					Transform torpedo = (Transform)Instantiate (torpedo_L_Heavy, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(HeavyTorpedo.heavySpeed, 0f);
				}
			}
		}
	}

	void OnCollisionEnter2D (Collision2D c) {
		Torpedo s = c.gameObject.GetComponent<Torpedo>();
		health = health - s.getDamage ();
		HealthBar.AddDamage ((int)s.getDamage ());
		Destroy (c.gameObject);
	}

	new void healthUpdate () {
		if (health <= 0) {
		gameover = true;
			announcement.text = "Blue sub wins!\n\nPress enter to\nstart a new game";
			announcement.material.color = Color.black;
		}
	}
}