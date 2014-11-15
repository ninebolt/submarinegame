﻿using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour {
	public int type;
	public int damage;
	public float speed;
	public float blastRadius;
	public float stun;
	public bool interceptor;
	public bool cleanup;
	public bool directionRight;

	// Use this for initialization
	void Start () {

	}

	public void LateStart() {
		if (directionRight) {
			rigidbody2D.velocity = new Vector2(speed, 0f);
		}
		else {
			rigidbody2D.velocity = new Vector2(-speed, 0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}