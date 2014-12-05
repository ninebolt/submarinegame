using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour {
	//public GameObject submarineGame;
	public float cooldown;
	public float damage;
	public float speed;
	public float blastRadius;
	public float stun;
	public bool interceptor;
	public int type;
	public bool directionRight;
	public GUIText healthGUI;
	public GameObject sound;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float getDamage () {
		return damage;
	}

	public void OnTriggerExit2D (Collider2D c)  {
		Destroy (gameObject);
	}

	public void PlaySound() {
		Instantiate (sound);
	}
}