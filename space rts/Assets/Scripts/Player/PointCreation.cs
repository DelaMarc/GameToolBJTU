using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCreation : MonoBehaviour {
	
	public GameObject point;
	public CustomPointUI ui;

	GameObject pointHolder;

	// Use this for initialization
	void Start () {
		//ui = FindObjectOfType<CustomPointUI> ();
		ui.gameObject.SetActive (false);
		Disable ();
		pointHolder = GameObject.Find ("customPointsHolder");
	}

	public void Enable(){
		ui.gameObject.SetActive (true);
		Debug.Log (ui.gameObject.activeSelf);
		this.enabled = true;
	}

	public void Disable(){
		ui.gameObject.SetActive (false);
		this.enabled = false;
	}

	GameObject CreatePointHolder(){
		GameObject grid = GameObject.Find ("Grid");

		pointHolder = new GameObject ("customPointsHolder");
		pointHolder.transform.position = grid.transform.position;
		pointHolder.transform.SetParent (grid.transform);
		return (pointHolder);

	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray;
		GameObject instance;

		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			return;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonDown(0)){
			Physics.Raycast (ray.origin, ray.direction, out hit);
			if (hit.collider == null) {
				ui.DeSelectPoint ();
			}
			else if (hit.collider.tag == "lineCollider") {
				point.transform.position = hit.point;// - (hit.point.normalized / 4);
				instance = Instantiate (point);
				if (pointHolder != null) {
					instance.transform.SetParent (pointHolder.transform);
				} else {
					instance.transform.SetParent (CreatePointHolder().transform);
				}
				ui.SelectPoint (instance.transform);
			} else if (hit.collider.tag == "customPoint") {
				ui.SelectPoint (hit.collider.transform);
			}

		}
	}
}
