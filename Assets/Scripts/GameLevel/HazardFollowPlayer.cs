using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardFollowPlayer : MonoBehaviour {

	public GameObject target;
	public GameObject followObject;

	public float aggroDistance;
	public float moveSpeed;
	public float attackRange;
	public int coolDownTime;

	public Vector3 guardPoint;

	public bool isAggroed;
	public bool canAttack;
	public bool isCoolingDown;

	int coolDownTimeCounter;
	int coolDownStart;

	// Use this for initialization
	void Start () {
		isCoolingDown = false;
	}
	
	// Update is called once per frame
	void Update () {
		AggroSwitch ();

		if (!isCoolingDown) {
			if (isAggroed) {
				MoveTowardsTarget (target.transform.position);
				AttackPossible ();
			} else {
				//MoveTowardsTarget (guardPoint);
			}
		}

		if (isCoolingDown) {
			CoolDownTimeOut ();
		}
	}

	void MoveTowardsTarget(Vector3 target){
		transform.position = Vector3.MoveTowards (transform.position, target+Vector3.up*2, moveSpeed * Time.deltaTime);
	}

	void AggroSwitch (){
		if (Vector3.Distance (target.transform.position, this.transform.position) < aggroDistance) {
			isAggroed = true;
		} else {
			isAggroed = false;
		}
	}

	void AttackPossible (){
		if (Vector3.Distance (target.transform.position, this.transform.position-Vector3.up*2) < attackRange) {
			canAttack = true;
			AttackTarget ();
		} else {
			canAttack = false;
		}
	}

	void AttackTarget (){
		print ("Player attacked");
		isCoolingDown = true;
		canAttack = false;
		coolDownTimeCounter = coolDownTime;
		coolDownStart = (int)Time.timeSinceLevelLoad;
		print (coolDownStart);

	}

	void CoolDownTimeOut(){
		if (coolDownStart + 3 < (int)Time.timeSinceLevelLoad) {
			isCoolingDown = false;
		}
	}

	public void SaveGuardPosition(){
		guardPoint = this.transform.position;
	}
}
