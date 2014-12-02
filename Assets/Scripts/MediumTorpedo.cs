using UnityEngine;
using System.Collections;

class MediumTorpedo : Torpedo {
	public static readonly float mediumCooldown = 0.5f;
	public static readonly float mediumDamage = 2f;
	public static readonly float mediumSpeed = 2f;
	public static readonly float mediumBlastRadius = 1f;
	public static readonly float mediumStun = 0f;
	public static readonly bool mediumInterceptor = false;
	public static readonly int mediumType = SubmarineGame.MEDIUM_TORPEDO;
	
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
		
	}
}