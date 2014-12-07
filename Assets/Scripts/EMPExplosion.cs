using UnityEngine;
using System.Collections;

public class EMPExplosion : Torpedo {
	public static readonly float mediumDamage = 0f;
	public static readonly float mediumStun = 2.25f;
	public static readonly float lifetime = 2f;
	private float lifeTime;

	// Use this for initialization
	void Start () {
		stun = mediumStun;
		damage = mediumDamage;
		type = SubmarineGame.MEDIUM_TORPEDO;
		lifeTime = lifetime;
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime <= 0f) {
			Destroy (this.gameObject);
		}
		lifeTime -= Time.deltaTime;
	}
}
