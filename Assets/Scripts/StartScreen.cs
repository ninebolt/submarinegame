using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	private int selectedItem;
	private GameObject playUnderline, instrUnderline;

	// Use this for initialization
	void Start () {
		playUnderline = GameObject.Find ("playUnderline");
		instrUnderline = GameObject.Find ("instrUnderline");
		selectedItem = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton0) 
		    || Input.GetKeyDown (KeyCode.Return) 
		    || Input.GetKeyDown (KeyCode.KeypadEnter)) {
			if (selectedItem == 0) {
				Application.LoadLevel(1);
			}
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			selectedItem++;
			Debug.Log ("UP: " + selectedItem);
		} else if (Input.GetKeyDown (KeyCode.S)) {
			selectedItem++;
			Debug.Log ("DOWN: " + selectedItem);
		}
		selectedItem = selectedItem % 2;

		updateSelection ();
	}

	private void updateSelection () {
		if (selectedItem == 0) {
			playUnderline.renderer.enabled = true;
			instrUnderline.renderer.enabled = false;
		} else if (selectedItem == 1) {
			playUnderline.renderer.enabled = false;
			instrUnderline.renderer.enabled = true;
		}
	}
}
