using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractWithItems : MonoBehaviour {

	public Text scoreText;
	public int playerScore;

	// Use this for initialization
	void Start () {
		AddScore (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "PointsItem" && !col.gameObject.GetComponent<InteractiveItem>().isInteracted) {
			int scoreValue = col.gameObject.GetComponent<InteractiveItem> ().pointsValue;
			col.gameObject.GetComponent<InteractiveItem> ().isInteracted = true;

			Destroy (col.gameObject);
			AddScore (scoreValue);
		}
	}

	void AddScore(int scoreValue){
		playerScore = playerScore + scoreValue;
		scoreText.text = "Score: " + playerScore;
	}

}
