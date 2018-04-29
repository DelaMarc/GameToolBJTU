using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

	public GridData gridData;

	 int width;
	 int widthSpace;

	//public int length;
	 int length;
	 int lengthSpace;

	//public int depth;
	 int depth;
	 int depthSpace;

	 //GameObject mapPoint;
	 //GameObject line;

	Transform mapOrigin;
	GameObject[][] points;
	Vector3 startPosition;
	GameObject pointsHolder;
	GameObject linesHolder;

	// Use this for initialization
	void Start () {
		length = width;
		depth = width;
	}
		

	void Init(){
		int i;

		width = gridData.scale;
		length = gridData.scale;
		depth = gridData.scale;
		widthSpace = gridData.widthSpace;
		lengthSpace = gridData.lengthSpace;
		depthSpace = gridData.depthSpace;

		mapOrigin = transform;
		pointsHolder = GetChildByName("pointsHolder");
		points = new GameObject[depth][];
		//lines = new GameObject[width * length * depth];
		for (i = 0; i < depth; ++i) {
			points[i] = new GameObject[width * length];
		}
		startPosition = new Vector3 (mapOrigin.position.x - ((width * widthSpace) / 2),mapOrigin.position.y - ((length * lengthSpace) / 2),mapOrigin.position.z - ((depth * depthSpace) / 2));
	}

	GameObject GetChildByName(string name){
		GameObject createdChild;

		foreach (Transform child in transform) {
			if (child.name == name) {
				return (child.gameObject);
			}
		}
		createdChild = new GameObject ();
		createdChild.transform.parent = this.transform;
		createdChild.name = name;
		return(createdChild);
	}
		
	public void Reset(){
		List<GameObject> childs;

		childs = new List<GameObject> ();
		if (points != null) {
			/*for (i = 0; i < points.Length; ++i) {
				for (j = 0; j < points [i].Length; ++j) {
					//childs.Add (points[i][j]);
					//DestroyImmediate (points [i][j]);
				}
			}*/
			foreach (Transform child in pointsHolder.transform) {
				childs.Add (child.gameObject);
				//DestroyImmediate (child.gameObject);
			}
			//Debug.Log ("child count: " + transform.childCount);
		}

		if (linesHolder != null) {
			foreach (Transform child in linesHolder.transform) {
				childs.Add (child.gameObject);
			}
		}
		childs.ForEach (child => DestroyImmediate(child));
		Init ();
	}

	void linkPoints(Transform A, Transform B){
		GameObject createdLine;
		Line lineScript;

		createdLine = Instantiate (gridData.line);
		createdLine.transform.parent = linesHolder.transform;
		lineScript = gridData.line.GetComponent<Line> ();
		lineScript.ApplyPoints (A,B);
	}

	void SetupLineRenderers(){
		int x, y, z;

		linesHolder = GetChildByName("linesHolder");
		for (z = 0; z < depth; ++z) {
			for (y = 0; y < length; ++y) {
				for (x = 0; x < width; ++x) {
					if (x + 1 < width) {
						//le point suivant existe sur l'axe X
						linkPoints(points[z][y * length + x].transform, points[z][y * length + x + 1].transform);
					}
					if (y + 1 < length) {
						//le point suivant existe sur l'axe Y
						linkPoints(points[z][y * length + x].transform, points[z][(y + 1) * length + x].transform);
					}
					if (z + 1 < depth) {
						linkPoints(points[z][y * length + x].transform, points[z + 1][y * length + x].transform);
					}
				}
			}

		}
	}

	public void CreateGrid(){
		int z;
		int zSpace;

		Reset ();
		zSpace = 0;
		for (z = 0; z < depth; ++z) {
			CreatePlan (z, zSpace);
			zSpace += depthSpace;
		}
		SetupLineRenderers ();
	}

	void CreatePlan(int z, int zSpace){
		int y;
		int ySpace;


		ySpace = 0;
		for (y = 0; y < length; ++y) {
			CreateLine (y, ySpace, z, zSpace);
			ySpace += lengthSpace;
		}
	}

	void CreateLine(int y, int ySpace, int z, int zSpace){
		int x;
		Vector3 pointPosition;

		pointPosition = new Vector3(startPosition.x, startPosition.y + ySpace, startPosition.z + zSpace);
		for (x = 0; x < width; ++x) {
			points[z][y * length + x] =Instantiate (gridData.mapPoint) as GameObject;
			points[z][y * length + x].transform.position = pointPosition;
			points[z][y * length + x].transform.parent = pointsHolder.transform;
			pointPosition = new Vector3 (pointPosition.x + widthSpace, pointPosition.y, pointPosition.z);
		}
	}
}
