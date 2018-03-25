using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour {

	public bool isClosed;
	Animation anim;

	public GameObject player;
	public float activationRange;
	public bool canBeActivated;
	public bool firstOpen;

	public GameObject[] contents;

	public Vector3 pushDirection;
	public float pushStrength;

	// Use this for initialization
	void Start () {
		firstOpen = true;
		isClosed = true;
		anim = this.GetComponent<Animation> ();
		CloseLid ();
	}
	
	// Update is called once per frame
	void Update () {
		CheckActivation ();
	}

	public void TurnSwitch(){
		if (isClosed) {
			if (firstOpen) {
				PopContents ();
				//firstOpen = false;
				OpenLid ();
			} else {
				OpenLid ();
			}
		} else if (!isClosed){
			CloseLid ();
		}
	}
	void CloseLid(){
		anim.Play (animation: "ChestClose");
		isClosed = true;
	}

	void OpenLid(){
		anim.Play (animation: "ChestOpen");
		isClosed = false;
	}

	void CheckActivation(){
		float dist = Vector3.Distance (player.transform.position, this.transform.position);

		if (dist < activationRange) {
			canBeActivated = true;
		} else {
			canBeActivated = false;
		}

		if (canBeActivated && Input.GetKeyDown(KeyCode.E)){
			TurnSwitch();
		}
	}

	void PopContents (){
		for (int i = 0; i < contents.Length; i++){
			print ("Popping item: " + 1);
			GameObject Popup = Instantiate (contents[i], transform.position + new Vector3(0.5f, 0.5f, 0.0f), transform.rotation);
			pushDirection.x = Random.Range (-0.6f, 0.6f);
			Popup.GetComponent<Rigidbody> ().AddForce(pushDirection*pushStrength,ForceMode.Impulse);
		}
	}
}
