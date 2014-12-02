using UnityEngine;
using System.Collections;

public class MotionSub_R : MotionSubmarine {
	public Burst burst;
	private Vector2 offset;
	private float cooldown;
	public Transform torpedo_R_Light;
	public Transform torpedo_R_Medium;
	public Transform torpedo_R_Heavy;
	
	new void Start () {
		Debug.Log ("Initialized!");
		maxSpeed = 5f * SubmarineGame.gameTempo * SubmarineGame.subSpeed;
		offset = new Vector2 (-0.8f, 0f);
		cooldown = 0f;
		health = 10;
	}

	// Update is called once per frame
	void Update () {
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);
		
		healthUpdate ();

		float move = Input.GetAxis ("VerticalAxis_2");
		
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move * maxSpeed);
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
		
		if(cooldown == 0f) {
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

	new void OnCollisionEnter2D (Collision2D c) {
		Torpedo s = c.gameObject.GetComponent<Torpedo>();
		health = health - s.getDamage ();
		Destroy (c.gameObject);
		
		Debug.Log ("Blue's New Health is: " + health);
	}
}