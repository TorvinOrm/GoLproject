using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour {

	public int pointsValue;
	public float rotationSpeed;
	public float scaleMaxSize;
	public float scaleMinSize;
	public float pulseSpeed;
	public bool isInteracted;

	bool isGrowing;

	Vector3 rotationV3;
//	Vector3 scaleMaxV3;
//	Vector3 scaleMinV3;


	// Use this for initialization
	void Start () {
		isGrowing = true;
		isInteracted = false;

		rotationV3 = new Vector3 (1.0f, 1.0f, 1.0f);
//		scaleMaxV3 = new Vector3 (scaleMaxSize, scaleMaxSize, scaleMaxSize);
//		scaleMinV3 = new Vector3 (scaleMinSize, scaleMinSize, scaleMinSize);
	}
	
	// Update is called once per frame
	void Update () {
		RotateItem ();
		PulseItem ();
	}

	void RotateItem(){
		this.transform.Rotate (rotationV3 * rotationSpeed);
	}

	void PulseItem(){

		if (this.transform.localScale.x >= scaleMaxSize) {
			isGrowing = false;
		} else if (this.transform.localScale.x <= scaleMinSize) {
			isGrowing = true;
		}


		if (this.transform.localScale.x <= scaleMaxSize && isGrowing) {
			this.transform.localScale += new Vector3 (pulseSpeed, pulseSpeed, pulseSpeed);
		} else if (transform.localScale.x >= scaleMinSize && !isGrowing) {
			this.transform.localScale -= new Vector3 (pulseSpeed, pulseSpeed, pulseSpeed);
		}
	}
}
