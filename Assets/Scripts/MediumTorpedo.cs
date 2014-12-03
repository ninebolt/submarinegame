using UnityEngine;
using System.Collections;

class MediumTorpedo : Torpedo {
	public static readonly float mediumCooldown = 3f;
	public static readonly float mediumDamage = 0f;
	public static readonly float mediumSpeed = 2f;
	public static readonly float mediumBlastRadius = 0.5f;
	public static readonly float mediumStun = 2.25f;
	public static readonly bool mediumInterceptor = false;
	public static readonly int mediumType = SubmarineGame.MEDIUM_TORPEDO;
	public GameObject EMPExplosion;
	public MotionSub_R motionSub_R;
	public MotionSub_L motionSub_L;
	
	// Use this for initialization
	void Start () {
		cooldown = mediumCooldown;
		damage = mediumDamage;
		speed = mediumSpeed;
		blastRadius = mediumBlastRadius;
		stun = mediumStun;
		interceptor = mediumInterceptor;
		type = mediumType;
	}

	void Update () {
		if(transform.position.x > SubmarineGame.rightWall) {
			DetonateRight();
		}
		if(transform.position.x < SubmarineGame.leftWall){
			DetonateLeft ();
		}
	}

	void DetonateRight() {

		float height = transform.position.y;
		float targetHeight = motionSub_R.transform.position.y;
		if(Mathf.Abs (height - targetHeight) < mediumBlastRadius) {
			motionSub_R.takeDamage (this);
		}
	}

	void DetonateLeft() {
		float height = transform.position.y;
	}
}