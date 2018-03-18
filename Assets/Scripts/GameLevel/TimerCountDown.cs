using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour {

	public Text countDown;
	public int counterStart;

	public bool counterOn;

	public int leftTime;

	int counter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		int timeVar = counterStart - (int)Time.timeSinceLevelLoad;
		leftTime = timeVar;
		if (timeVar > 0) {
			countDown.text = timeVar.ToString ();
		} else if (timeVar == 0) {
			countDown.text = "Level finished!";
			GameObject.Find ("GameController").GetComponent<FinishLevel> ().CloseLevel (3);
		}
	}

}
