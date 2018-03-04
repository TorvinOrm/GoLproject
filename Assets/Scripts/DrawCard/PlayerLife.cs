using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

	public int agesToBePlayed;
	public int levelsPerAge;

	public int currentAge;
	public int currentLevel;

	// Use this for initialization
	void Start () {
		if (currentAge == 0) {
			currentAge = 1;
		}

		if (currentLevel == 0){
			currentLevel = 0;
		}

		NextLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextLevel(){
		Debug.Log ("Deed is done");
		this.GetComponent<PlayerLife> ().currentLevel++;
	}
}
