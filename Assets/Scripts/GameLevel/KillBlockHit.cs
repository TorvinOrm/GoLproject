using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBlockHit : MonoBehaviour {


	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "KillBlock") {
			print ("kill block is hit");
			GameObject.Find ("GameController").GetComponent<FinishLevel> ().CloseLevel (1);
//			Destroy (this);
		}
	}
}
