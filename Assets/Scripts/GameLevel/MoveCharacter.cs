using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour {

	public float walkSpeed;
	public float jumpStrength;
	public float runSpeed;

	Vector3 moveForward;
	Vector3 jumpUp;

	public bool isJumped;
	public bool isAtLadder;

	float lastY;
//	CapsuleCollider playerCaps;
	float playerDefDrag;

	public int collisions;

	// Use this for initialization
	void Start () {
		moveForward = new Vector3 (1, 0, 0);
		jumpUp = new Vector3 (0, 1, 0);
		isJumped = false;

//		playerCaps = this.GetComponent<CapsuleCollider> ();

		playerDefDrag = this.GetComponent<Rigidbody> ().drag;
	}
	
	// Update is called once per frame
	void Update(){
		
		if (isJumped) {
			CheckIfJumped ();
		}

		IsInfrontLadder ();
		ReadInput ();

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
			collisions = -1;
			isJumped = true;
		}

		if (Input.GetAxis("Vertical") != 0 & isAtLadder) {
			this.transform.Translate (0.0f, Input.GetAxis("Vertical") * 0.2f, 0.0f);

		}
	}

	/// <summary>
	/// Checks if jumped - this is required in order to avoid multiple jumping from the air, i.e. it is possible only when the character is set on floor
	/// </summary>
	void CheckIfJumped(){

		if (collisions > 0) {
			isJumped = false;
		}
	}

	void OnCollisionEnter(Collision collision){
		collisions = 1;

		if (collision.gameObject.tag == "VertLadder") {
			MoveLadderClimbSetup ();
		} else {
			MoveWalkSetup ();
		}
	}

	void OnCollisionExit(Collision collision){
		collisions = -1;
	}

	void IsInfrontLadder(){
		Vector3 front = transform.TransformDirection (Vector3.forward + Vector3.up);
		Vector3 back = transform.TransformDirection (Vector3.back + Vector3.up);

		RaycastHit hit;

		if (Physics.Raycast (transform.position, back, out hit)) {
			if (hit.transform.tag == "VertLadder") {
				MoveLadderClimbSetup ();
			} else {
				MoveWalkSetup ();
			}

		} else if (Physics.Raycast (transform.position, front, out hit)) {
			if (hit.transform.tag == "VertLadder") {
				MoveLadderClimbSetup ();
			} else {
				MoveWalkSetup ();
			}

		} else {
			MoveWalkSetup ();
		}
	}

	public void MoveWalkSetup(){
		isAtLadder = false;
		this.GetComponent<Rigidbody> ().useGravity = true;
		this.GetComponent<Rigidbody> ().drag = playerDefDrag;
	}

	public void MoveLadderClimbSetup(){
		isAtLadder = true;
		this.GetComponent<Rigidbody> ().useGravity = false;
		this.GetComponent<Rigidbody> ().drag = 5;
	}

//	void OnCollisionEnter(Collision col){
////		if (col.gameObject.tag = "VertLadder") {
////			MoveLadderClimbSetup ();
////		} else {
////			MoveWalkSetup ();
////		}
//	}

}
