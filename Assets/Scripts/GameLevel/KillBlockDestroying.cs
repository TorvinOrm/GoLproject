using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBlockDestroying : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			print ("kill block is hit");
			GameObject.Find ("GameController").GetComponent<FinishLevel> ().CloseLevel (1);
			//			Destroy (this);
		} else {
			col.gameObject.SetActive(false);
			Destroy (col.gameObject);
		}
	}
}
