using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(HazardFollowPlayer))]
public class HazardGuardSaver : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector ();

		HazardFollowPlayer guardScript = (HazardFollowPlayer)target;

		if(GUILayout.Button("Save Guard Position")){
			guardScript.SaveGuardPosition ();
		}

	}
}
