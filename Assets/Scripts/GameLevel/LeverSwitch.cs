using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitch : MonoBehaviour {

	public GameObject switchBulb;
	public GameObject player;

	public float activationRange;
	public bool canBeActivated;

	public Material onMaterial;
	public Material offMaterial;

	public bool switchStatus;
	public GameObject connectedObject;
	public Vector3 onPosition;
	public Vector3 offPosition;

	Vector3 directionVector;

	public float speed;

	Animation anim;

	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		canBeActivated = false;
		 
		anim = this.GetComponent<Animation> ();
		SwitchOff ();
		if (switchStatus) {
			connectedObject.transform.position = onPosition;
			targetPosition = onPosition;

		} else {
			connectedObject.transform.position = offPosition;
			targetPosition = offPosition;

		}
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (player.transform.position, this.transform.position);

		if (dist < activationRange) {
			canBeActivated = true;
		} else {
			canBeActivated = false;
		}

		if (canBeActivated && Input.GetKeyDown (KeyCode.E)) {
			TurnSwitch ();
		}
	}

	void FixedUpdate(){
		if (connectedObject.transform.position != targetPosition) {
			connectedObject.transform.position = Vector3.MoveTowards (connectedObject.transform.position, targetPosition, speed*Time.deltaTime * speed);
		}
	}

	public void TurnSwitch(){
		if (switchStatus) {
			SwitchOff ();
		} else if (!switchStatus) {
			SwitchOn ();
		}
	}

	void SwitchOn(){
		anim.Play (animation: "switchOn");
		switchBulb.GetComponent<Renderer> ().material = onMaterial;
		if (connectedObject != null) {
			targetPosition = onPosition;
		}
//		connectedObject.transform.position = onPosition;

		switchStatus = true;
	}

	void SwitchOff(){
		anim.Play (animation: "switchOff");
		switchBulb.GetComponent<Renderer> ().material = offMaterial;
		if (connectedObject != null) {
			targetPosition = offPosition;
		}
//		connectedObject.transform.position = offPosition;
		switchStatus = false;
	}
		

	public void SaveOnPosition(){
		onPosition = connectedObject.transform.position;
	}

	public void SaveOffPosition(){
		offPosition = connectedObject.transform.position;
	}
}
