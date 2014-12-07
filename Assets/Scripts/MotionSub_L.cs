using UnityEngine;
using System.Collections;

public class MotionSub_L : MotionSubmarine {
	public Burst burst;
	private Vector2 offset;
	public Transform torpedo_L_Light;
	public Transform torpedo_L_Medium;
	public Transform torpedo_L_Heavy;
	
	new void Start () {
		Time.timeScale = 1;
		maxSpeed = 5f * SubmarineGame.gameTempo * SubmarineGame.subSpeed;
		offset = new Vector2 (0.8f, 0f);
		cooldown = 0f;
		health = SubmarineGame.maxHealth;
		healthBarOffset = new Vector3(0f, transform.localScale.y * 1.5f, 0f);
		gameover = false;
		hitstun = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameover) {
			if (Input.GetKeyDown (KeyCode.Joystick1Button7) || Input.GetKeyDown (KeyCode.Joystick2Button7)
			    	|| Input.GetKeyDown(KeyCode.Return)) {
				Application.LoadLevel (0);
			}
		}

		HealthBar.transform.position = transform.position + healthBarOffset;
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);
		EMPCooldown = Mathf.Max (0f, EMPCooldown - Time.deltaTime);
		NukeCooldown = Mathf.Max (0f, NukeCooldown - Time.deltaTime);
		healthUpdate ();
		hitstun = Mathf.Max (0f, hitstun - Time.deltaTime);

		float move = Input.GetAxis ("VerticalAxis_1");
		if((move > 0 && transform.position.y < upperLimit) || (move < 0 && transform.position.y > lowerLimit)) {
			if(hitstun == 0f) {
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move * maxSpeed);
			}
			else {
				rigidbody2D.velocity = new Vector2(0f, 0f);
			}
		}
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

		if(cooldown == 0f && hitstun == 0f) {	
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation = new Vector3(orientation.x,orientation.y,orientation.z+180);
			print (rigidbody2D.rotation);

			if(Input.GetKey (KeyCode.Joystick1Button0) || Input.GetKey (KeyCode.Alpha1)) {
				if(burst.fireLight ()){
					Transform torpedo = (Transform)Instantiate (torpedo_L_Light, ((Vector2)transform.position) 
							+ offset, Quaternion.Euler (new Vector3(orientation.x,orientation.y,rigidbody2D.rotation+180)));
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(LightTorpedo.lightSpeed, rigidbody2D.velocity.y * torpedoSlide);
				}
			}
			else if(Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Alpha2)
			        || Input.GetAxis ("RT_1") < -0.01f){
				if(burst.fireMedium ()){
					Transform torpedo = (Transform)Instantiate (torpedo_L_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(MediumTorpedo.mediumSpeed, 0f);
				}
			}
			else if(Input.GetKeyDown (KeyCode.Joystick1Button3) || Input.GetKeyDown (KeyCode.Alpha3)
			        || Input.GetAxis ("LT_1") < -0.01f){
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

	new void healthUpdate () {
		if (health <= 0) {
			gameover = true;
			announcement.text = "Blue sub wins!\n\nPress A to\nreturn to the menu";
			announcement.material.color = Color.black;
		}
	}
}