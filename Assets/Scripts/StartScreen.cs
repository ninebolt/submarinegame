using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("playUnderline").renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton0) || Input.GetKeyDown (KeyCode.Joystick2Button0)) {
			Application.LoadLevel (1);
		}
	
	}
}
