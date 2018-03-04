using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script operates the cards prefabs control - how many cards are to be taken, what cards are to be shown, how cards are positioned
/// </summary>
public class DrawCardController : MonoBehaviour {

	public int cardsQty;
	public int maxCardsInRow;
	public float distanceBetweenCards;
	public float distanceBetweenRows;
	public float rotationAngleBetweenCards;

	public GameObject card;


	// Use this for initialization
	void Start () {
		Debug.Log ("Start!");
		PopulateCards ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PopulateCards (){
		//find out whether cards quantity is bigger than allowed quantity in a row
		float rowsQty = (float)cardsQty / maxCardsInRow;

		if (rowsQty > 1) {
			//if cards qty is over allowed qty in a row...
			for (int i = 0; i < rowsQty; i++) {
				//...insert row of a full cards stack...
				if (maxCardsInRow * i < cardsQty - maxCardsInRow * i) {
					for (int j = 0; j < maxCardsInRow; j++) {
						//find the j-th element position in Vector3
						float xPos = (0 - (maxCardsInRow - 1) * distanceBetweenCards / 2) + j * distanceBetweenCards;
						Vector3 newPos = new Vector3 (xPos, 1.8f - distanceBetweenRows * i, -7.5f);
						//create a new object
						Instantiate (card, newPos, Quaternion.identity);
					}
				} else {
				//...otherwise insert partial cards stack
					for (int j = 0; j < cardsQty - maxCardsInRow * i; j++) {
						//find the j-th element position in Vector3
						float xPos = (0 - (cardsQty - maxCardsInRow * i - 1) * distanceBetweenCards / 2) + j * distanceBetweenCards;
						Vector3 newPos = new Vector3 (xPos, 1.8f - distanceBetweenRows * i, -7.5f);
						//create a new object
						Instantiate (card, newPos, Quaternion.identity);
					}
				}
			}
		} else {
			//...if cards quantity is smaller than allowed qty in a row..
			for (int i = 0; i < cardsQty; i++){
				//float xPos = (0 - (cardsQty - cardsQty * i - 1) * distanceBetweenCards / cardsQty);
				float xPos = (0 - (cardsQty-1) * distanceBetweenCards / 2) + i * distanceBetweenCards;
				Vector3 newPos = new Vector3 (xPos, 1.8f, -7.5f);
				Instantiate (card, newPos, Quaternion.identity);
			}
		}
	}
}
