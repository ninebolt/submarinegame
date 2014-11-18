using UnityEngine;
using System.Collections;

class HeavyTorpedo : Torpedo {
	public static readonly float cooldown = 3f;
	public static readonly float damage = 3f;
	public static readonly float speed = 1f;
	public static readonly float blastRadius = 1f;
	public static readonly bool interceptor = false;
	
	// Use this for initialization
	void Start () {
		LateStart ();
	}

	void Update () {
		
	}
}