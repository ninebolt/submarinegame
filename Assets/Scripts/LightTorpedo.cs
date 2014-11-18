using UnityEngine;
using System.Collections;

class LightTorpedo : Torpedo {
	public static readonly float lightCooldown = 1f;
	public static readonly float lightDamage = 1f;
	public static readonly float lightSpeed = 3f;
	public static readonly float lightBlastRadius = 1f;
	public static readonly float lightStun = 0f;
	public static readonly bool lightInterceptor = false;
	public static readonly int lightType = SubmarineGame.LIGHT_TORPEDO;
	
	// Use this for initialization
	void Start () {		
		cooldown = lightCooldown;
		damage = lightDamage;
		speed = lightSpeed;
		blastRadius = lightBlastRadius;
		stun = lightStun;
		interceptor = lightInterceptor;
		type = lightType;
	}

	void Update () {
		
	}
}