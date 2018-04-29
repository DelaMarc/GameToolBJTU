using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	public Transform pointA;
	public Transform pointB;
	//public BoxCollider col;
	public CapsuleCollider col;
	[Range(0.1f,1f)]
	public float width = 0.5f;

	public Vector3 oldPosA;
	public Vector3 oldPosB;

	public LineRenderer line;
	public Vector3[] vertices;

	// Use this for initialization
	public void Start () {
		if (pointA == null || pointB == null)
			return;
		oldPosA = pointA.position;
		oldPosB = pointB.position;
		line = GetComponent<LineRenderer> ();
		line.startWidth = width;
		line.endWidth = width;
		line.positionCount = 2;
		setLineRenderer ();
		setLineCollider ();
	}

	public void setLineRenderer(){
		vertices = new Vector3[2];
		vertices [0] = pointA.position;
		vertices [1] = pointB.position;
		line.SetPositions (vertices);
	}

	public void setLineCollider()
	{
		Vector3 startPos, endPos;
		Vector3 midPoint;

		startPos = pointA.position;
		endPos = pointB.position;
		col.height = (endPos - startPos).magnitude;
		midPoint = (startPos + endPos)/2;
		col.radius = width / 2;
		col.transform.position = midPoint; // setting position of collider object
		col.transform.LookAt(endPos);
		col.transform.Rotate (new Vector3 (90, 0, 0));
	}

	public void ApplyPoints(Transform A, Transform B){
		pointA = A;
		pointB = B;
		Start ();
	}
		
}
