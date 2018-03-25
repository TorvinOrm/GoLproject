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
	Vector3 onPosition;
	Vector3 offPosition;
	public Quaternion onRotation;
	public Quaternion offRotation;

	Vector3 directionVector;

	public float speed;

	Animation anim;

	Vector3 targetPosition;
	Quaternion targetRotation;

	// Use this for initialization
	void Start () {

		if (connectedObject.GetComponent<ObjectPositionSaver> () != null) {
			//reading the on/off data from the connected object - if it must move/rotate
			onPosition = connectedObject.GetComponent<ObjectPositionSaver> ().onPosition;
			offPosition = connectedObject.GetComponent<ObjectPositionSaver> ().offPosition;

			onRotation = connectedObject.GetComponent<ObjectPositionSaver> ().onRotation;
			offRotation = connectedObject.GetComponent<ObjectPositionSaver> ().offRotation;
		} else if (connectedObject.GetComponent<ObjectPositionSaver> () != null) {
			//reading the chest open/clos - if it has chest script on it

		}

		canBeActivated = false;
		anim = this.GetComponent<Animation> ();
		SwitchOff ();
		if (switchStatus) {
			connectedObject.transform.position = onPosition;
			targetPosition = onPosition;
			targetRotation = onRotation;

		} else {
			connectedObject.transform.position = offPosition;
			targetPosition = offPosition;
			targetRotation = offRotation;
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
			connectedObject.transform.rotation = Quaternion.RotateTowards (connectedObject.transform.rotation, targetRotation,speed*Time.deltaTime * speed*15);

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
			targetRotation = onRotation;
		}

		switchStatus = true;
	}

	void SwitchOff(){
		anim.Play (animation: "switchOff");
		switchBulb.GetComponent<Renderer> ().material = offMaterial;
		if (connectedObject != null) {
			targetPosition = offPosition;
			targetRotation = offRotation;
		}
		switchStatus = false;
	}
}
