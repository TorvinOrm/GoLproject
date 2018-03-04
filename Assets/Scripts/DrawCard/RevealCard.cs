using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCard : MonoBehaviour {

	public GameObject[] cards;
	GameObject cardToReveal;

	public void InitRevealCard(){
		DecreaseCardCounter ();
		//RevealSelectedCard ();
	}

	void DecreaseCardCounter(){
		GameObject counter = GameObject.Find ("DrawCardGameController");
		int count = counter.GetComponent<RevealedCardCounter>().cardsLeftToReveal;

		if (count > 0) {
			RevealSelectedCard ();
			counter.GetComponent<RevealedCardCounter> ().cardsLeftToReveal--;
		} else {
			Debug.Log ("You cannot forseek your future anymore...");
		}
	}

	void RevealSelectedCard(){
		cards = GameObject.FindGameObjectsWithTag ("Card");
		foreach (GameObject card in cards) {
			if (card.GetComponent<CardInteraction> ().cardSelected) {
				card.GetComponent<CardInteraction> ().RevealCard ();
			}
		}

	}
}
