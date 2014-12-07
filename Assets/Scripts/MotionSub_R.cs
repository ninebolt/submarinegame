using UnityEngine;
using System.Collections;

public class MotionSub_R : MotionSubmarine {
	public Burst burst;
	private Vector2 offset;
	public Transform torpedo_R_Light;
	public Transform torpedo_R_Medium;
	public Transform torpedo_R_Heavy;
	
	new void Start () {
		Time.timeScale = 1;
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
		if (gameover) {
			if (Input.GetKeyDown (KeyCode.Joystick1Button0) 
			    || Input.GetKeyDown (KeyCode.Joystick2Button0)
			    || Input.GetKeyDown (KeyCode.A)) {
				Application.LoadLevel (0);
			}
		}

		HealthBar.transform.position = transform.position + healthBarOffset;
		healthUpdate ();
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);
		EMPCooldown = Mathf.Max (0f, EMPCooldown - Time.deltaTime);
		NukeCooldown = Mathf.Max (0f, NukeCooldown - Time.deltaTime);
		hitstun = Mathf.Max (0f, hitstun - Time.deltaTime);

		float move = Input.GetAxis ("VerticalAxis_2");
		if((move > 0 && transform.position.y < upperLimit) || (move < 0 && transform.position.y > lowerLimit)) {
			if(hitstun == 0f) {	
				rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move * maxSpeed);
			}
			else {
				rigidbody2D.velocity = new Vector2(0f, 0f);
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
		print (Input.GetAxis ("RT_2"));
		
		if(cooldown == 0f && hitstun == 0f) {
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation = new Vector3(orientation.x,orientation.y,orientation.z);

			if(Input.GetKey (KeyCode.Joystick2Button0) || Input.GetKey (KeyCode.Alpha7)){
				if(burst.fireLight ()){
					Transform torpedo = (Transform)Instantiate (torpedo_R_Light, ((Vector2)transform.position) 
							+ offset, Quaternion.Euler (new Vector3(orientation.x,orientation.y,rigidbody2D.rotation)));
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(-LightTorpedo.lightSpeed, rigidbody2D.velocity.y * torpedoSlide);
				}
			}
			else if(Input.GetKeyDown (KeyCode.Joystick2Button1) || Input.GetKeyDown ( KeyCode.Alpha8)
			        || Input.GetAxis ("RT_2") < -0.01f){
				if(burst.fireMedium ()){
					Transform torpedo = (Transform)Instantiate (torpedo_R_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
					cooldown += SubmarineGame.allTorpedoCooldown;
					torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
						* new Vector2(-MediumTorpedo.mediumSpeed, 0f);
				}
			}
			else if(Input.GetKeyDown (KeyCode.Joystick2Button3) || Input.GetKeyDown ( KeyCode.Alpha9)
			        || Input.GetAxis ("LT_2") < -0.01f){
				if(burst.fireHeavy ()){
					Transform torpedo = (Transform)Instantiate (torpedo_R_Heavy, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
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

	new void healthUpdate () {
		if (health <= 0) {
			gameover = true;
			announcement.text = "Red sub wins...\n\nPress A to\nreturn to the menu";
			announcement.material.color = Color.black;
		}
	}
}