using UnityEngine;
using System.Collections;

public class Burst : MonoBehaviour {
	public static readonly int lightTorpedoCap = 10;
	public static readonly int mediumTorpedoCap = 1;
	public static readonly int heavyTorpedoCap = 1;

	private int lightTorpedoCharges;
	private int mediumTorpedoCharges;
	private int heavyTorpedoCharges;

	private float lightCharge;
	private float mediumCharge;
	private float heavyCharge;

	public GameObject empStock, nukeStock;

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
		updateGUI ();

		if(lightTorpedoCharges < lightTorpedoCap) {
			lightCharge += Time.deltaTime * SubmarineGame.gameTempo;
			if(lightCharge >= LightTorpedo.lightCooldown) {
				lightTorpedoCharges++;
				if(lightTorpedoCharges == lightTorpedoCap) {
					lightCharge = 0f;
				}
				else {
					lightCharge -= LightTorpedo.lightCooldown;
				}
			}
		}
		else {
			lightCharge = 0f;
			lightTorpedoCharges = lightTorpedoCap;
		}

		if(mediumTorpedoCharges < mediumTorpedoCap) {
			mediumCharge += Time.deltaTime * SubmarineGame.gameTempo;
			if(mediumCharge >= MediumTorpedo.mediumCooldown) {
				mediumTorpedoCharges++;
				if(mediumTorpedoCharges == mediumTorpedoCap) {
					mediumCharge = 0f;
				}
				else {
					mediumCharge -= MediumTorpedo.mediumCooldown;
				}
			}
		}
		else {
			mediumCharge = 0f;
			mediumTorpedoCharges = mediumTorpedoCap;
		}

		if(heavyTorpedoCharges < heavyTorpedoCap) {
			heavyCharge += Time.deltaTime * SubmarineGame.gameTempo;
			if(heavyCharge >= HeavyTorpedo.heavyCooldown) {
				heavyTorpedoCharges++;
				if(heavyTorpedoCharges == heavyTorpedoCap) {
					heavyCharge = 0f;
				}
				else {
					heavyCharge -= HeavyTorpedo.heavyCooldown;
				}
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

	public bool fireLight() {
		if(lightTorpedoCharges > 0) {
			lightTorpedoCharges--;
			return true;
		}
		else {
			lightTorpedoCharges = 0;
			return false;
		}
	}

	public bool fireMedium() {
		if(mediumTorpedoCharges > 0) {
			mediumTorpedoCharges--;
			return true;
		}
		else {
			mediumTorpedoCharges = 0;
			return false;
		}
	}

	public bool fireHeavy() {
		if(heavyTorpedoCharges > 0) {
			heavyTorpedoCharges--;
			return true;
		}
		else {
			heavyTorpedoCharges = 0;
			return false;
		}
	}

	private void updateGUI () {
		if (mediumTorpedoCharges > 0) {
			empStock.renderer.enabled = true;
		} else {
			empStock.renderer.enabled = false;
		}

		if (heavyTorpedoCharges > 0) {
			nukeStock.renderer.enabled = true;
		} else {
			nukeStock.renderer.enabled = false;
		}
	}
}
