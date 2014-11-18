using UnityEngine;
using System.Collections;

class LightTorpedo : Torpedo {
	public static readonly float cooldown = 1f;
	public static readonly float damage = 1f;
	public static readonly float speed = 3f;
	public static readonly float blastRadius = 1f;
	public static readonly bool interceptor = false;
	
	// Use this for initialization
	void Start () {		
		LateStart ();
	}

	void Update () {
		
	}
}