using UnityEngine;
using System.Collections;

class HeavyTorpedo : Torpedo {
	public static readonly float heavyCooldown = 10f;
	public static readonly float heavyDamage = 3f;
	public static readonly float heavySpeed = 2f;
	public static readonly float heavyBlastRadius = 1f;
	public static readonly float heavyStun = 0f;
	public static readonly bool heavyInterceptor = false;
	public static readonly int heavyType = SubmarineGame.HEAVY_TORPEDO;
	public GameObject L_nukeSplashObj;
	public GameObject R_nukeSplashObj;
	
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
			Instantiate (L_nukeSplashObj, new Vector3(3.487008f, curLoc.y, 0f), new Quaternion(0f, 0f, 0f, 0f));
		} 
		else {
			Instantiate (R_nukeSplashObj, new Vector3(-3.487008f, curLoc.y, 0f), new Quaternion(0f, 0f, 0f, 0f));
		}
	}
}