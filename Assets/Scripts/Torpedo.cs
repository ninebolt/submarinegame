using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour {
	public int damage;
	public float speed;
	public float blastRadius;
	public float stun;
	public bool interceptor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

class LightTorpedo : Torpedo {
	
	// Use this for initialization
	void Start () {
		damage = 1;
		speed = 3.0f;
		blastRadius = 1.0f;
		stun = 0f;
		interceptor = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

class MediumTorpedo : Torpedo {
	
	// Use this for initialization
	void Start () {
		damage = 2;
		speed = 2.0f;
		blastRadius = 1.0f;
		stun = 0f;
		interceptor = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

class HeavyTorpedo : Torpedo {
	
	// Use this for initialization
	void Start () {
		damage = 3;
		speed = 1.0f;
		blastRadius = 1.0f;
		stun = 0f;
		interceptor = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}