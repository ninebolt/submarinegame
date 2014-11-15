using UnityEngine;
using System.Collections;

class LightTorpedo : Torpedo {
	public static readonly float cooldown = 1f;
	
	// Use this for initialization
	void Start () {
		damage = 1;
		speed = 3.0f;
		blastRadius = 0f;
		stun = 0f;
		interceptor = false;
		cleanup = false;
		
		LateStart ();
	}

	void Update () {
		
	}
}