using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour {
	public float cooldown;
	public float damage;
	public float speed;
	public float blastRadius;
	public float stun;
	public bool interceptor;
	public int type;
	public bool directionRight;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D (Collider2D c) {
		Debug.Log ("Woosh!");
		Destroy (gameObject);
	}

	public float getDamage() {
		return damage;
	}
}