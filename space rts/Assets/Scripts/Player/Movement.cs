using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector3.forward * speed);
		}
		else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (Vector3.back * speed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector3.left * speed);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector3.right * speed);
		}

		if (Input.GetMouseButton (1)) {
			if (Input.GetAxis ("Mouse X") > 0f) {
				transform.Rotate (Vector3.up * speed);
			} else if (Input.GetAxis ("Mouse X") < 0f) {
				transform.Rotate (Vector3.down * speed);
			}
		} else if (Input.GetMouseButton (2)) {
			if (Input.GetAxis ("Mouse Y") > 0f) {
				transform.Translate (Vector3.up * speed);
			} else if (Input.GetAxis ("Mouse Y") < 0f) {
				transform.Translate (Vector3.down * speed);
			}
		}
	}
}
