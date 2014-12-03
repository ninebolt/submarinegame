using UnityEngine;
using System.Collections;

public class EMPExplosion : Torpedo {
	public static readonly float mediumDamage = 0f;
	public static readonly float mediumStun = 2.25f;
	private float lifeTime = 2f;

	// Use this for initialization
	void Start () {
		stun = mediumStun;
		damage = mediumDamage;
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime <= 0f) {
			Destroy (this.gameObject);
		}
		lifeTime -= Time.deltaTime;
	}
}
