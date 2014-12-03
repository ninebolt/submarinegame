using UnityEngine;
using System.Collections;

public class EMPExplosion : Torpedo {
	public static readonly float mediumDamage = 0f;
	public static readonly float mediumStun = 2.25f;

	// Use this for initialization
	void Start () {
		stun = mediumStun;
		damage = mediumDamage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
