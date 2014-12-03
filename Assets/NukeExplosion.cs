using UnityEngine;
using System.Collections;

public class NukeExplosion : Torpedo {
	public static readonly float heavyDamage = 3f;
	public static readonly float heavyStun = 0f;
	
	// Use this for initialization
	void Start () {
		stun = heavyStun;
		damage = heavyDamage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
