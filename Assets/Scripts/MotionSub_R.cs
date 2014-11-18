using UnityEngine;
using System.Collections;

public class MotionSub_R : MotionSubmarine {
	private Vector2 offset;
	private float cooldown;
	public Transform torpedo_R_Light;
	public Transform torpedo_R_Medium;
	public Transform torpedo_R_Heavy;
	
	new void Start () {
		Debug.Log ("Initialized!");
		maxSpeed = 5f;
		torpedoes = new ArrayList ();
		offset = new Vector2 (-0.8f, 0f);
		cooldown = 0f;
		health = 10;
	}

	// Update is called once per frame
	void Update () {
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);
		
		float move = Input.GetAxis ("VerticalAxis_2");
		
		rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, move * maxSpeed);
		Rotate ();
		
		if(cooldown == 0f) {	
			if(Input.GetKeyDown (KeyCode.Joystick2Button0) || Input.GetKeyDown (KeyCode.Alpha7)){
				Transform torpedo = (Transform)Instantiate (torpedo_R_Light, ((Vector2)transform.position) 
			             + offset, Quaternion.identity);
				cooldown += LightTorpedo.cooldown;
				//adjust velocity
			}
			else if(Input.GetKeyDown (KeyCode.Joystick2Button1) || Input.GetKeyDown ( KeyCode.Alpha8)){
				Transform torpedo = (Transform)Instantiate (torpedo_R_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.identity);
				cooldown += MediumTorpedo.cooldown;
				//adjust velocity
			}
			else if(Input.GetKeyDown (KeyCode.Joystick2Button3) || Input.GetKeyDown ( KeyCode.Alpha9)){
				Transform torpedo = (Transform)Instantiate (torpedo_R_Heavy, ((Vector2)transform.position) 
				                                            + offset, Quaternion.identity);
				cooldown += HeavyTorpedo.cooldown;
				//adjust velocity
			}
		}
	}	

	void OnCollisionEnter2D (Collision2D c) {
		Debug.Log ("Hit!");
		
		Destroy (c.gameObject);
		
		LightTorpedo s = c.gameObject.GetComponent<LightTorpedo>();
		
		health = health - s.damage;
		Debug.Log ("New Health is: " + health);
	}
}