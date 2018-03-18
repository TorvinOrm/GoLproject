using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {

	int countInit;

	// Use this for initialization
	void Start () {
		countInit = -1;
	}
	
	// Update is called once per frame
	void Update () {
		int timeVar = countInit - (int)Time.timeSinceLevelLoad;

		if (timeVar == 0) {
			GameObject.Find ("Timer").GetComponent<TimerCountDown> ().counterStart = 0;
			SceneManager.LoadScene ("DrawCard");
		}
	}

	public void CloseLevel(int timer){
		countInit = timer + (int)Time.timeSinceLevelLoad;

	}
}
