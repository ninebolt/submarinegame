using UnityEngine;
using System.Collections;

public class MotionSub_L : MotionSubmarine {
	private Vector2 offset;
	private float cooldown;
	public Transform torpedo_L_Light;
	public Transform torpedo_L_Medium;
	public Transform torpedo_L_Heavy;
	
	new void Start () {
		Debug.Log ("Initialized!");
		maxSpeed = 5f;
		torpedoes = new ArrayList ();
		offset = new Vector2 (0.8f, 0f);
		cooldown = 0f;
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);

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
			rotation = new Vector3(rotation.x,rotation.y,rotation.z+180);

			if(Input.GetKeyDown (KeyCode.Joystick1Button0) || Input.GetKeyDown (KeyCode.Alpha1)) {
				Transform torpedo = (Transform)Instantiate (torpedo_L_Light, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				cooldown += LightTorpedo.cooldown;
				torpedo.rigidbody2D.velocity = new Vector2(LightTorpedo.speed, rigidbody2D.velocity.y);
			}
			else if(Input.GetKeyDown (KeyCode.Joystick1Button1) || Input.GetKeyDown (KeyCode.Alpha2)){
				Transform torpedo = (Transform)Instantiate (torpedo_L_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				cooldown += MediumTorpedo.cooldown;
				torpedo.rigidbody2D.velocity = new Vector2(MediumTorpedo.speed, rigidbody2D.velocity.y);
			}
			else if(Input.GetKeyDown (KeyCode.Joystick1Button3) || Input.GetKeyDown (KeyCode.Alpha3)){
				Transform torpedo = (Transform)Instantiate (torpedo_L_Heavy, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				cooldown += HeavyTorpedo.cooldown;
				torpedo.rigidbody2D.velocity = new Vector2(HeavyTorpedo.speed, rigidbody2D.velocity.y);
			}
		}
	}
}