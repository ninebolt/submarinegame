using UnityEngine;
using System.Collections;

public class NukeExplosion : Torpedo {
	public static readonly float heavyDamage = 3f;
	public static readonly float heavyStun = 0f;
	private float lifetime = 2f;
	
	// Use this for initialization
	void Start () {
		stun = heavyStun;
		damage = heavyDamage;
		type = SubmarineGame.HEAVY_TORPEDO;
	}
	
	// Update is called once per frame
	void Update () {
		if (lifetime <= 0f) {
			Destroy (this.gameObject);
		}
		lifetime -= Time.deltaTime;
	}
}
