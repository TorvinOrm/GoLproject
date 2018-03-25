using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionSaver : MonoBehaviour {

	public Vector3 onPosition;
	public Vector3 offPosition;

	public Quaternion onRotation;
	public Quaternion offRotation;


	public void SaveOnPosition(){
		onPosition = transform.position;
	}

	public void SaveOffPosition(){
		offPosition = transform.position;
	}

	public void SaveOnRotation(){
		onRotation = transform.rotation;
	}

	public void SaveOffRotation(){
		offRotation = transform.rotation;
	}
}
