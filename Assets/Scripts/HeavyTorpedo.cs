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
	public GameObject nukeSplashObj;
	
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

	}

	void OnDestroy () {
		Vector3 curLoc = this.gameObject.transform.position;
		if (curLoc.x > 0) {
			Instantiate (nukeSplashObj, new Vector3(3.487008f, curLoc.y, 0f), new Quaternion(0f, 0f, 0f, 0f));
		} else {
			Instantiate (nukeSplashObj, new Vector3(-3.487008f, curLoc.y, 0f), new Quaternion(0f, 0f, 0f, 0f));
		}
	}
}