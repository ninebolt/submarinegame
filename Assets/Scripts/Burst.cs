using UnityEngine;
using System.Collections;

public class Burst : MonoBehaviour {
	public static readonly int lightTorpedoCap = 6;
	public static readonly int mediumTorpedoCap = 4;
	public static readonly int heavyTorpedoCap = 2;

	private float lightCharge;
	private float mediumCharge;
	private float heavyCharge;

	private int lightTorpedoCharges;
	private int mediumTorpedoCharges;
	private int heavyTorpedoCharges;

	// Use this for initialization
	void Start () {
		lightCharge = 0;
		mediumCharge = 0;
		heavyCharge = 0;

		lightTorpedoCharges = 0;
		mediumTorpedoCharges = 0;
		heavyTorpedoCharges = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(lightTorpedoCharges < lightTorpedoCap) {
			lightCharge += Time.deltaTime;
			if(lightCharge >= LightTorpedo.lightCooldown) {

			}
		}
		else {
			lightCharge = 0f;
			lightTorpedoCharges = lightTorpedoCap;
		}

		if(mediumTorpedoCharges < mediumTorpedoCap) {
			mediumCharge += Time.deltaTime;
			if(mediumCharge >= MediumTorpedo.mediumCooldown) {
				
			}
		}
		else {
			mediumCharge = 0f;
			mediumTorpedoCharges = mediumTorpedoCap;
		}

		if(heavyTorpedoCharges < heavyTorpedoCap) {
			heavyCharge += Time.deltaTime;
			if(heavyCharge >= HeavyTorpedo.heavyCooldown) {
				
			}
		}
		else {
			heavyCharge = 0f;
			heavyTorpedoCharges = heavyTorpedoCap;
		}
	}

	public int getLightCharges() {
		return lightTorpedoCharges;
	}

	public int getMediumCharges() {
		return mediumTorpedoCharges;
	}

	public int getHeavyCharges() {
		return heavyTorpedoCharges;
	}

	public void fireLight() {
		lightTorpedoCharges--;
	}

	public void fireMedium() {
		mediumTorpedoCharges--;
	}

	public void fireHeavy() {
		heavyTorpedoCharges--;
	}
}
