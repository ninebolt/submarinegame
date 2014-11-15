using UnityEngine;
using System.Collections;

public class MotionSub_R : MotionSubmarine {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			MoveUp ();
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			MoveDown ();
		}
		else {
			Stop();
		}
	}	
}