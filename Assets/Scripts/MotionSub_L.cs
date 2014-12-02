using UnityEngine;
using System.Collections;

public class MotionSub_L : MotionSubmarine {
	private Burst burst;
	private Vector2 offset;
	private float cooldown;
	public Transform torpedo_L_Light;
	public Transform torpedo_L_Medium;
	public Transform torpedo_L_Heavy;
	
	new void Start () {
		Debug.Log ("Initialized!");
		maxSpeed = 5f * SubmarineGame.gameTempo * SubmarineGame.subSpeed;
		offset = new Vector2 (0.8f, 0f);
		cooldown = 0f;
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
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
				Transform torpedo = (Transform)Instantiate (torpedo_L_Light, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				burst.fireLight ();
				cooldown += cooldown;
				torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
					* new Vector2(LightTorpedo.lightSpeed, 0f);//rigidbody2D.velocity.y * 0.25f);
			}
			else if(Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Alpha2)){
				Transform torpedo = (Transform)Instantiate (torpedo_L_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				burst.fireMedium ();
				cooldown += cooldown;
				torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
					* new Vector2(MediumTorpedo.mediumSpeed, 0f);
			}
			else if(Input.GetKeyDown (KeyCode.Joystick1Button3) || Input.GetKeyDown (KeyCode.Alpha3)){
				Transform torpedo = (Transform)Instantiate (torpedo_L_Heavy, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				burst.fireHeavy ();
				cooldown += cooldown;
				torpedo.rigidbody2D.velocity = SubmarineGame.torpedoSpeed * SubmarineGame.gameTempo
					* new Vector2(HeavyTorpedo.heavySpeed, 0f);
			}
		}
	}

	new void OnCollisionEnter2D (Collision2D c) {
		
		Torpedo s = c.gameObject.GetComponent<Torpedo>();
		health = health - s.getDamage ();
		Destroy (c.gameObject);
		
		Debug.Log ("Red's New Health is: " + health);
	}
}