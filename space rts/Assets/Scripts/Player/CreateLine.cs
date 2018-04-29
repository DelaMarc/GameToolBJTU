using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour {

	public LineCreationUI ui;

	GameObject linesHolder;
	GameObject line;
	int pointCount;
	Transform A,B;
	List<string> acceptedTags;

	// Use this for initialization
	void Start () {
		//ui = FindObjectOfType<LineCreationUI> ();
		linesHolder = GameObject.Find("customLinesHolder");
		pointCount = 0;
		acceptedTags = new List<string>{"customPoint", "staticPoint", "ship"};
		ui.gameObject.SetActive (false);
		line = ui.line;
		Disable ();
	}
		
	public void Enable(){
		ui.gameObject.SetActive (true);
		this.enabled = true;
	}

	public void Disable(){
		ui.gameObject.SetActive (false);
		this.enabled = false;
	}

	GameObject SetLineHolder(){
		GameObject grid = GameObject.Find ("Grid");

		linesHolder = new GameObject ("customLinesHolder");
		linesHolder.transform.position = grid.transform.position;
		linesHolder.transform.SetParent (grid.transform);
		return (linesHolder);
	}

	void Deselect(){
		A = null;
		pointCount = 0;
		ui.Deselect (pointCount);
	}

	void Select(Transform point){
		GameObject instance;

		if (pointCount == 0) {
			A = point;
			++pointCount;
			ui.SetMessage (pointCount);
			//text.text = messages[pointCount];
		} else if (pointCount == 1) {
			//instantiate line
			instance = Instantiate(line);
			instance.GetComponent<DynamicLine> ().ApplyPoints (A, point);
			if (linesHolder != null) {
				instance.transform.SetParent (linesHolder.transform);
			} else {
				instance.transform.SetParent (SetLineHolder().transform);
			}
			Deselect();
		}
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray;

		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			return;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonDown(0)){
			Physics.Raycast (ray.origin, ray.direction, out hit);
			if (hit.collider == null) {
				Deselect ();
			} else if (acceptedTags.Contains (hit.collider.tag)) {
				Select (hit.transform);
				//ui.Select (hit.transform);
			}

		}
	}
}