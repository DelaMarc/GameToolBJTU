using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour {

	public Vector3 direction;

	//Vector3 lastPos;
	//Vector3 delta;
	float speed = 1f;

	Transform parent;

	// Use this for initialization
	void Start () {
		//lastPos = Vector3.zero;
		parent = transform.parent;
	}

	void OnMouseDown(){
		//lastPos = Input.mousePosition;
	}

	void OnMouseDrag(){
		//Debug.Log ("horizontal: " + Input.GetAxis("Mouse X"));
		//Debug.Log ("vertical: " + Input.GetAxis("Mouse Y"));
		//delta = Input.mousePosition - lastPos;

		if (direction == Vector3.up) {
			Debug.Log ("Y axis");
			HandleYAxis ();
		} else if (direction == Vector3.right) {
			Debug.Log ("X axis");
			HandleXAxis ();
		} else if (direction == Vector3.forward) {
			Debug.Log ("Z axis");
			HandleZAxis();
		}
	}

	void HandleXAxis(){
		if (Input.GetAxis ("Mouse X") > 0f) {
			parent.Translate (direction.normalized * speed * Time.deltaTime);
		}
		else if (Input.GetAxis ("Mouse X") < 0f) {
			parent.Translate (-direction.normalized * speed * Time.deltaTime);
		}
	}

	void HandleYAxis(){
		if (Input.GetAxis ("Mouse Y") > 0f) {
			parent.Translate (direction.normalized * speed * Time.deltaTime);
		}
		else if (Input.GetAxis ("Mouse Y") < 0f) {
			parent.Translate (-direction.normalized * speed * Time.deltaTime);
		}
	}

	void HandleZAxis(){
		if (Input.GetAxis ("Mouse X") > 0f || Input.GetAxis ("Mouse Y") > 0f) {
			parent.Translate (direction.normalized * speed * Time.deltaTime);
		}
		else if (Input.GetAxis ("Mouse X") < 0f || Input.GetAxis ("Mouse Y") < 0f) {
			parent.Translate (-direction.normalized * speed * Time.deltaTime);
		}
	}


	// Update is called once per frame
	void Update () {
		
	}
}
