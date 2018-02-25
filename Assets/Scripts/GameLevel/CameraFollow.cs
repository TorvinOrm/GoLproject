using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	public GameObject levelCamera;
	Vector3 cameraPosition;

	// Use this for initialization
	/// <summary>
	/// Use this to get the distance between camera and player
	/// </summary>
	void Start () {
		cameraPosition = levelCamera.GetComponent<Transform> ().position - player.GetComponent<Transform> ().position;
	}
	
	/// <summary>
	/// Update camera position and hold in against the player
	/// </summary>
	void Update () {
		levelCamera.transform.position = player.transform.position + cameraPosition;
	}
}
