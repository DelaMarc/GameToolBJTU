using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadronController : MonoBehaviour {
	[Range(0.1f, 5)]
	public float speed;
	public float distanceStop;

	Transform goal;

	public bool isMoving{
		get{ 
			return (goal != null);
		}
	}

	// Use this for initialization
	void Start () {
		goal = null;
	}
		
	public void SetDest(Transform d){
		goal = d;
		Debug.Log ("destination set");
	}

	void LateUpdate(){
		Vector3 direction;
		if (goal != null) {
			direction = (goal.position - transform.position).normalized * speed;
			transform.Translate (direction, Space.World);
		}
	}

	// Update is called once per frame
	void Update () {
		Vector3 distance;

		if (goal != null) {
			distance = goal.position - transform.position;
			if (distance.magnitude <= distanceStop) {
				goal = null;
			}
		}
	}
}
