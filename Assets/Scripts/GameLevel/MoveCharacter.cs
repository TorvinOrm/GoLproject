using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

	public float walkSpeed;
	public float jumpStrength;
	public float runSpeed;

	Vector3 moveForward;
	Vector3 jumpUp;

	bool isJumped;

	float lastY;

	// Use this for initialization
	void Start () {
		moveForward = new Vector3 (1, 0, 0);
		jumpUp = new Vector3 (0, 1, 0);
		isJumped = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		ReadInput ();
	}

	void FixedUpdate(){
		if (isJumped) {
			CheckIfJumped ();
		}

	}

	/// <summary>
	/// Reads the player input
	/// </summary>
	void ReadInput(){
		if (Input.GetAxis ("Horizontal") != 0 & isJumped) {
			this.GetComponent<Rigidbody> ().AddForce (moveForward * walkSpeed/2 * Input.GetAxis("Horizontal"));
		}

		if (Input.GetAxis ("Horizontal")!=0 & !isJumped) {
			this.GetComponent<Rigidbody> ().AddForce (moveForward * walkSpeed * Input.GetAxis("Horizontal"));
		}

		if (Input.GetKeyDown(KeyCode.Space) & !isJumped){
			this.GetComponent<Rigidbody> ().AddForce (jumpUp * jumpStrength);
			isJumped = true;
		}
	}

	/// <summary>
	/// Checks if jumped - this is required in order to avoid multiple jumping from the air, i.e. it is possible only when the character is set on floor
	/// </summary>
	void CheckIfJumped(){
		if (lastY == this.transform.position.y) {
			isJumped = false;
		}
		lastY = this.transform.position.y;
	}
}
