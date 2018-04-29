using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

	public int obstacleRaycastMultuplier = 50;
	public int speedChangePercentage = 10;
	public int applyRulesPercentage = 20;

	public FlockManager manager;
	Vector3 direction;
	float speed;
	bool turning = false;

	// Use this for initialization
	void Start () {
		
	}

	void ApplyRules(){
		Flock anotherFlock;
		GameObject[] gos;
		Vector3 vCentre, vAvoid, direction;
		float gSpeed, nDistance;
		int groupSize;

		gos = manager.allFighters;
		vCentre = Vector3.zero;
		vAvoid = Vector3.zero;
		gSpeed = 0.01f;
		groupSize = 0;

		foreach (GameObject go in gos) {
			if (go != this.gameObject) {
				nDistance = Vector3.Distance (go.transform.position, this.transform.position);
				if (nDistance <= manager.neighbourDistance) {
					vCentre += go.transform.position;
					groupSize++;

					if (nDistance < 1.0f) {
						vAvoid += (this.transform.position - go.transform.position);
					}
					anotherFlock = go.GetComponent<Flock> ();
					gSpeed = gSpeed + anotherFlock.speed;
				}
			}
		}
		if (groupSize > 0) {
			vCentre = vCentre / groupSize + (manager.goalPos - this.transform.position);
			speed = gSpeed / groupSize;
			direction = (vCentre + vAvoid) - transform.position;
			if (direction != Vector3.zero) {
				transform.rotation = Quaternion.Slerp (transform.rotation,
														Quaternion.LookRotation(direction),
														manager.rotationSpeed * Time.deltaTime);
			}
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		if (turning) {
			//direction = manager.transform.position - transform.position;
			transform.rotation = Quaternion.Slerp (transform.rotation,
				Quaternion.LookRotation (direction),
				manager.rotationSpeed * Time.deltaTime);
		} else {
			if (Random.Range (0, 100) < speedChangePercentage) {
				speed = Random.Range (manager.minSpeed, manager.maxSpeed);
			}
			if (Random.Range (0, 100) < applyRulesPercentage) {
				ApplyRules ();
			}
			ApplyRules ();
		}
		transform.Translate (0,0, Time.deltaTime * speed);
	}

	//AMELIORATION POSSIBLE: utiliser des colliders au lieu d'un raycast
	// --> résultat plus précis mais plus gourmand en ressources
	void Update(){
		RaycastHit hit;
		Bounds b;

		b = new Bounds (manager.transform.position, manager.flyLimits * 2);
		hit = new RaycastHit ();
		direction = Vector3.zero;
		if (!b.Contains (transform.position)) {
			turning = true;
			direction = manager.transform.position - transform.position;
		}
		else if (Physics.Raycast(transform.position, this.transform.forward * obstacleRaycastMultuplier, out hit)) {
			//if (LayerMask.LayerToName (hit.transform.gameObject.layer) == "shipFlockCollisionLayer") {
				turning = true;
				direction = Vector3.Reflect (this.transform.forward, hit.normal);
			//}
		} else {
			turning = false;
			//Debug.DrawRay (transform.position, this.transform.forward * obstacleRaycastMultuplier, Color.red);
		}
	}
}
