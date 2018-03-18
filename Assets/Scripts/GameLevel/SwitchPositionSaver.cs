using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(LeverSwitch))]
public class SwitchPositionSaver : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();

		LeverSwitch switchScript = (LeverSwitch)target;

		if (GUILayout.Button ("Save On Position")) {
			switchScript.SaveOnPosition ();
		}

		if (GUILayout.Button ("Save Off Position")) {
			switchScript.SaveOffPosition ();
		}
	}
}
