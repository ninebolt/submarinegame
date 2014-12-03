using UnityEngine;
using System.Collections;

class HeavyTorpedo : Torpedo {
	public static readonly float heavyCooldown = 1f;
	public static readonly float heavyDamage = 2f;
	public static readonly float heavySpeed = 1f;
	public static readonly float heavyBlastRadius = 1f;
	public static readonly float heavyStun = 0f;
	public static readonly bool heavyInterceptor = false;
	public static readonly int heavyType = SubmarineGame.HEAVY_TORPEDO;
	
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
}