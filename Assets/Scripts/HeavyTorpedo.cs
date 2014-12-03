using UnityEngine;
using System.Collections;

class HeavyTorpedo : Torpedo {
	public static readonly float heavyCooldown = 1.5f;
	public static readonly float heavyDamage = 2f;
	public static readonly float heavySpeed = 1f;
	public static readonly float heavyBlastRadius = 1f;
	public static readonly float heavyStun = 0f;
	public static readonly bool heavyInterceptor = false;
	public static readonly int heavyType = SubmarineGame.HEAVY_TORPEDO;
	public GameObject NukeExplosion;
	public MotionSub_R motionSub_R;
	public MotionSub_L motionSub_L;
	
	// Use this for initialization
	void Start () {
		cooldown = heavyCooldown;
		damage = heavyDamage;
		speed = heavySpeed;
		blastRadius = heavyBlastRadius;
		stun = heavyStun;
		interceptor = heavyInterceptor;
		type = heavyType;
	}

	void Update () {
		if(transform.position.x > SubmarineGame.rightWall) {
			DetonateRight();
		}
		if(transform.position.x < SubmarineGame.leftWall){
			DetonateLeft();
		}
	}

	public void DetonateRight() {
		float height = transform.position.y;

	}
	
	public void DetonateLeft() {
		float height = transform.position.y;
	}
}