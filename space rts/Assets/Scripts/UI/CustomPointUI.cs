using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomPointUI : MonoBehaviour {
	public float speed;

	Transform point;
	bool pressed;
	Vector3 direction;


	public void DeletePoint(){
		if (point != null) {
			Destroy (point.gameObject);
			DeSelectPoint ();

		}
	}

	public void SelectPoint(Transform p){
		point = p;
		foreach (Transform child in transform) {
			//if (child.gameObject.name != "Back") {
				child.gameObject.SetActive (true);
			//}
		}
		//this.gameObject.SetActive (true);
	}

	public void DeSelectPoint(){
		point = null;
		foreach (Transform child in transform) {
			if (child.gameObject.name != "Back") {
				child.gameObject.SetActive (false);
		}
		}
		//gameObject.SetActive (false);
	}


	public void SetupHold(Vector3 dir){
		direction = dir * speed;
		pressed = true;
	}

	public void unsetHold(){
		pressed = false;
	}

	void Move(){
		if (point == null)
			return;
		point.Translate (direction);
	}

	void Update(){
		if (pressed) {
			Move ();
		}
	}
}
