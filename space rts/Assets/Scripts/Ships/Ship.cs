using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	public float rotationAngle;

	Transform goal;
	bool rotating;

	// Use this for initialization
	void Start () {
		goal = null;
		rotating = false;
	}

	public bool IsMoving(){
		return ((goal != null) || rotating);
	}

	public void SetDest(Transform dest){
		goal = dest;
	}


	void LateUpdate(){
		Vector3 direction;

		if (goal != null) {
			direction = goal.position - transform.position;
			rotating = Quaternion.Angle (Quaternion.LookRotation (direction), transform.rotation) > rotationAngle;
			if (rotating) {
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotateSpeed);
			} else {
				//rotates in movement
				direction = (goal.position - transform.position).normalized * moveSpeed;
				//direction = transform.forward * moveSpeed;
				transform.Translate (direction, Space.World);
			}
			if (transform.rotation != Quaternion.LookRotation (direction)){
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotateSpeed);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 distance;
		if (goal != null) {
			distance = goal.position - transform.position;
			if (distance.magnitude < 1f) {
				goal = null;
			}
		}
	}
}
