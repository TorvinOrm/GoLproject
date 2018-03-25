using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(ObjectPositionSaver))]
public class SwitchPositionSaver : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();

		ObjectPositionSaver switchScript = (ObjectPositionSaver)target;

		if (GUILayout.Button ("Save On Position and Rotation")) {
			switchScript.SaveOnPosition ();
			switchScript.SaveOnRotation ();
		}

		if (GUILayout.Button ("Save Off Position and Rotation")) {
			switchScript.SaveOffPosition ();
			switchScript.SaveOffRotation ();
		}
	}
}
