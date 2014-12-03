using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	private int health;
	public GameObject Damage1;
	public GameObject Damage2;
	public GameObject Damage3;
	public GameObject Damage4;
	public GameObject Damage5;
	public GameObject Damage6;
	public GameObject Damage7;
	public GameObject Damage8;
	public GameObject Damage9;
	public GameObject Damage10;
	private GameObject[] Damages;

	// Use this for initialization
	void Start () {
		health = SubmarineGame.maxHealth;
		Damages = new GameObject[10]{Damage1, Damage2, Damage3, Damage4,
			Damage5, Damage6, Damage7, Damage8, Damage9, Damage10};
		setFullHealth();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {
		for(int i = 0; i < SubmarineGame.maxHealth - health; i++) {
			Damages[i].SetActive (true);
		}
		for(int i = SubmarineGame.maxHealth-health; i < SubmarineGame.maxHealth; i++) {
			Damages[i].SetActive (false);
		}
	}

	public void AddDamage(int damage) {
		health = Mathf.Max (0, health - damage);
	}

	public void setFullHealth() {
		for(int i = 0; i < 10; i++) {
			Damages[i].SetActive (false);
		}
	}
}
