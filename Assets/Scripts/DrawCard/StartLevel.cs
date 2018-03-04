using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

	public string gameLevelName;
	public GameObject[] cards;

	public GameObject playerStats;

	// Use this for initialization
	void Start () {

	}

	public void ButtonPressed(){
		gameLevelName = "GameLevel";

		cards = GameObject.FindGameObjectsWithTag ("Card");
		foreach (GameObject card in cards) {
			if (card.GetComponent<CardInteraction> ().cardSelected & card.GetComponent<CardInteraction> ().cardRevealed) {
				Debug.Log ("You made your choice!");
				InitLevel ();
				break;
			} else if (card.GetComponent<CardInteraction> ().cardSelected & !card.GetComponent<CardInteraction> ().cardRevealed) {
				Debug.Log ("Your courage pleases Gods!");
				InitLevel ();
				break;
			}
		}
	}

	void InitLevel(){
		SceneManager.LoadScene (gameLevelName);
	}
}
