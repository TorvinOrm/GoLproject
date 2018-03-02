using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInteraction : MonoBehaviour {

	public Color defaultColor;
	public Color hoveredColor;
	public Color clickedColor;
	public Color selectedColor;
	public Color revealedColor;
	public Color selectRevealedColor;

	public bool cardSelected;
	public bool cardRevealed;

	public GameObject[] cards;
	//public GameObject card;

	void Start(){
		cardSelected = false;
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			SelectCard ();
		} else if (Input.GetMouseButton (0) & !cardSelected & !cardRevealed) {
			this.gameObject.GetComponent<Renderer> ().material.color = clickedColor;
		} else if (this.gameObject.GetComponent<Renderer> ().material.color != hoveredColor & !cardSelected & !cardRevealed) {
			this.gameObject.GetComponent<Renderer> ().material.color = hoveredColor;
		} else if (Input.GetMouseButton (0) & !cardSelected & cardRevealed) {
			this.gameObject.GetComponent<Renderer> ().material.color = revealedColor;
		}
	}

	void OnMouseExit(){
		if (this.gameObject.GetComponent<Renderer> ().material.color != defaultColor & !cardSelected & !cardRevealed) {
			this.gameObject.GetComponent<Renderer> ().material.color = defaultColor;
		}
	}

	void SelectCard(){

		//must reset all the cards before setting current card as "selected"
		cards = GameObject.FindGameObjectsWithTag ("Card");
		foreach (GameObject card in cards) {
			if (!card.GetComponent<CardInteraction> ().cardRevealed) {
				card.GetComponent<Renderer> ().material.color = defaultColor;
				card.GetComponent<CardInteraction> ().cardSelected = false;
			} else if(card.GetComponent<CardInteraction>().cardRevealed){
				card.GetComponent<Renderer> ().material.color = revealedColor;
				card.GetComponent<CardInteraction> ().cardSelected = false;
			}
		}
		//set current card as "selected"
		if (!cardRevealed) {
			this.gameObject.GetComponent<Renderer> ().material.color = selectedColor;
			cardSelected = true;
		} else if (this.cardRevealed) {
			this.GetComponent<Renderer> ().material.color = selectRevealedColor;
			this.cardSelected = true;
		}
	}

	public void RevealCard(){
		if (!this.cardRevealed) {
			this.GetComponent<Renderer> ().material.color = revealedColor;
			this.cardRevealed = true;
		} 
	}
		


}
