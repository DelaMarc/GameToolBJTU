using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {
	public ShipControlUI ui;

	protected Ship ship;
	protected List<string> acceptedDest;

	// Use this for initialization
	void Start () {
		acceptedDest = new List<string>(){"staticPoint", "customPoint", "ship"};
		ship = null;
		ui.gameObject.SetActive (false);
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

	void SelectShip(){
		RaycastHit hit;
		Ray ray;

		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			return;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonDown(0)){
			Physics.Raycast (ray.origin, ray.direction, out hit);
			if (hit.collider == null) {
				ui.Deselect ();
			}
			else if (hit.collider.tag == "ship") {
				ui.Select ();
				ship = hit.collider.transform.GetComponent<Ship>();
				if (ship != null)
					ui.UpdateUI (ship.gameObject.transform);
			} else {
				Debug.Log (hit.collider.tag);
				ui.Deselect ();
			}

		}
	}

	void OrderMove(){
		RaycastHit hit;
		Ray ray;

		if (ship == null)
			return;
		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			return;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonDown(1)){
			Physics.Raycast (ray.origin, ray.direction, out hit);
			if (hit.collider != null && acceptedDest.Contains(hit.collider.tag)) {
				ship.SetDest (hit.collider.transform);
			} 
		}
	}

	// Update is called once per frame
	void Update () {
		SelectShip ();
		OrderMove ();
		if (ship != null && ship.IsMoving ())
			ui.UpdateUI (ship.transform);
	}
}
