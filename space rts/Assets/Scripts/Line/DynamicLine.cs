using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLine : Line {

	void Start(){
		base.Start ();
	}

	// Update is called once per frame
	void Update () {
		if (pointA == null || pointB == null) {
			Destroy (gameObject);
			return;
		}

		if (oldPosA != pointA.position || oldPosB != pointB.position) {
			oldPosA = pointA.position;
			oldPosB = pointB.position;
			setLineRenderer ();
			setLineCollider ();
		}
	}
}
