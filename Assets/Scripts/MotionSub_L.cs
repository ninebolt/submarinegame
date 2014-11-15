using UnityEngine;
using System.Collections;

public class MotionSub_L : MotionSubmarine {

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			MoveUp ();
		}
		else if (Input.GetKey (KeyCode.S)) {
			MoveDown ();
		}
		else {
			Stop();
		}
	}	
}