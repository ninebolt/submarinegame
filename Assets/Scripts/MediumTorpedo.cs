using UnityEngine;
using System.Collections;

class MediumTorpedo : Torpedo {
	public static readonly float cooldown = 2f;
	public static readonly float damage = 2f;
	public static readonly float speed = 2f;
	public static readonly float blastRadius = 1f;
	public static readonly bool interceptor = false;
	
	// Use this for initialization
	void Start () {
		LateStart ();
	}

	void Update () {
		
	}
}