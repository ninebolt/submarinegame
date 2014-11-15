using UnityEngine;
using System.Collections;

public class MotionSub_L : MotionSubmarine {
	private Vector2 offset;
	private float cooldown;
	public Transform torpedo_R_Light;
	public Transform torpedo_R_Medium;
	public Transform torpedo_R_Heavy;
	
	new void Start () {
		Debug.Log ("Initialized!");
		maxSpeed = 5f;
		torpedoes = new ArrayList ();
		offset = new Vector2 (1.5f, 0f);
		cooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);

		if (Input.GetKey (KeyCode.W)) {
			MoveUp ();
		}
		else if (Input.GetKey (KeyCode.S)) {
			MoveDown ();
		}
		else {
			Stop();
		}
		
		print (cooldown);
		if(cooldown == 0f) {	
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation = new Vector3(rotation.x,rotation.y+180,rotation.z);

			if(Input.GetKeyDown ( KeyCode.Alpha1)){
				Transform torpedo = (Transform)Instantiate (torpedo_R_Light, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				cooldown += LightTorpedo.cooldown;
				//adjust velocity
			}
			else if(Input.GetKeyDown ( KeyCode.Alpha2)){
				Transform torpedo = (Transform)Instantiate (torpedo_R_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				cooldown += MediumTorpedo.cooldown;
				//adjust velocity
			}
			else if(Input.GetKeyDown ( KeyCode.Alpha3)){
				Transform torpedo = (Transform)Instantiate (torpedo_R_Heavy, ((Vector2)transform.position) 
				                                            + offset, Quaternion.Euler (rotation));
				cooldown += HeavyTorpedo.cooldown;
				//adjust velocity
			}
		}
	}
}