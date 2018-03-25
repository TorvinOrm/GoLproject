using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour {

	public int healthPoints;
	public Text hpText;

	// Use this for initialization
	void Start () {
		hpText.text = "Hp: " + healthPoints;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		
	}

	public void ChangeHealth(int healthChange){
		healthPoints = healthPoints + healthChange;
		hpText.text = "Hp: " + healthPoints;

		if (this.gameObject.tag == "Player" & healthPoints <= 0) {
			print ("kill block is hit");
			GameObject.Find ("GameController").GetComponent<FinishLevel> ().CloseLevel (1);
		} else if (healthPoints <= 0) {
			this.gameObject.SetActive (false);
			Destroy (this.gameObject);
		}
	}
}
