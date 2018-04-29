using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadronControl : MonoBehaviour {

	public ShipControlUI ui;

	SquadronController squadron;
	List<string> acceptedDest;


	// Use this for initialization
	void Start () {
		acceptedDest = new List<string>(){"staticPoint", "customPoint", "ship", "squadron"};
		squadron = null;
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
			else if (hit.collider.tag == "fighter") {
				ui.Select ();
				squadron = hit.collider.transform.GetComponent<Flock> ().manager.GetComponent<SquadronController> ();
				if (squadron != null)
					ui.UpdateUI (squadron.gameObject.transform);
			} else {
				Debug.Log (hit.collider.tag);
				ui.Deselect ();
			}

		}
	}

	void OrderMove(){
		RaycastHit hit;
		Ray ray;

		if (squadron == null)
			return;
		if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			return;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonDown(1)){
			Physics.Raycast (ray.origin, ray.direction, out hit);
			if (hit.collider != null && acceptedDest.Contains(hit.collider.tag)) {
				squadron.SetDest (hit.collider.transform);
			} 
		}
	}

	// Update is called once per frame
	void Update () {
		SelectShip ();
		OrderMove ();
		if (squadron != null && squadron.isMoving)
			ui.UpdateUI (squadron.transform);
	}
}
