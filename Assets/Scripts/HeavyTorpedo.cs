using UnityEngine;
using System.Collections;

class HeavyTorpedo : Torpedo {
	public static readonly float cooldown = 3f;
	
	// Use this for initialization
	void Start () {
		damage = 3;
		speed = 1.0f;
		blastRadius = 0f;
		stun = 0f;
		interceptor = false;
		cleanup = false;
		
		LateStart ();
	}

	void Update () {
		
	}
}