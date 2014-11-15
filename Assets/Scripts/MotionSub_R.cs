using UnityEngine;
using System.Collections;

public class MotionSub_R : MotionSubmarine {
	private Vector2 offset;
	private float cooldown;
	public Transform torpedo_L_Light;
	public Transform torpedo_L_Medium;
	public Transform torpedo_L_Heavy;
	
	new void Start () {
		Debug.Log ("Initialized!");
		maxSpeed = 5f;
		torpedoes = new ArrayList ();
		offset = new Vector2 (-1.5f, 0f);
		cooldown = 0f;
	}

	// Update is called once per frame
	void Update () {
		cooldown = Mathf.Max (0f, cooldown - Time.deltaTime);

		if (Input.GetKey (KeyCode.UpArrow)) {
			MoveUp ();
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			MoveDown ();
		}
		else {
			Stop();
		}

		print (cooldown);
		if(cooldown == 0f) {	
			if(Input.GetKeyDown ( KeyCode.Alpha7)){
				Transform torpedo = (Transform)Instantiate (torpedo_L_Light, ((Vector2)transform.position) 
			             + offset, Quaternion.identity);
				cooldown += LightTorpedo.cooldown;
				//adjust velocity
			}
			else if(Input.GetKeyDown ( KeyCode.Alpha8)){
				Transform torpedo = (Transform)Instantiate (torpedo_L_Medium, ((Vector2)transform.position) 
				                                            + offset, Quaternion.identity);
				cooldown += MediumTorpedo.cooldown;
				//adjust velocity
			}
			else if(Input.GetKeyDown ( KeyCode.Alpha9)){
				Transform torpedo = (Transform)Instantiate (torpedo_L_Heavy, ((Vector2)transform.position) 
				                                            + offset, Quaternion.identity);
				cooldown += HeavyTorpedo.cooldown;
				//adjust velocity
			}
		}
	}	
}