using UnityEngine;
using System.Collections;

public class SubmarineGame : MonoBehaviour {
	public static readonly float gameTempo = 1f;
	public static readonly float subSpeed = 0.5f;
	public static readonly float torpedoSpeed = 1.5f;
	public static readonly float allTorpedoCooldown = 0.15f;
	public static readonly int maxHealth = 10;
	public static readonly float leftWall = -3.45f;
	public static readonly float rightWall = 3.45f;

	public static readonly int LIGHT_TORPEDO = 0;
	public static readonly int MEDIUM_TORPEDO = 1;
	public static readonly int HEAVY_TORPEDO = 2;

	public MotionSub_R motionSub_R;
	public MotionSub_L motionSub_L;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.KeypadEnter)){
			if(motionSub_R.gameover || motionSub_L.gameover){
				restart ();
			}
		}
	}

	public void restart() {

	}
}