using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMapPoint : Point {

	public Transform x;
	public Transform y;
	public Transform z;
	public float lineWidth;

	// Use this for initialization
	void Start () {
		//SetDirectionLineRenderer (x, Vector3.right);
		//SetDirectionLineRenderer (y, Vector3.up);
		//SetDirectionLineRenderer (x, Vector3.forward);
	}

	private void SetDirectionLineRenderer(Transform point, Vector3 direction){
		LineRenderer line = point.GetComponent<LineRenderer> ();
		Vector3[] vertices = new Vector3[]{transform.position, point.position,};

		line.positionCount = 2;
		//line.startWidth = lineWidth;
		//line.endWidth = lineWidth;
		line.SetPositions (vertices);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
