using UnityEngine;
using System.Collections;

class MediumTorpedo : Torpedo {
	public static readonly float cooldown = 2f;
	
	// Use this for initialization
	void Start () {
		damage = 2;
		speed = 2.0f;
		blastRadius = 0f;
		stun = 0f;
		interceptor = false;
		cleanup = false;

		LateStart ();
	}

	void Update () {
		
	}
}