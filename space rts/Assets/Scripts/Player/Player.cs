using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject mainUI;

	string status;
	CreateLine createLine;
	PointCreation pointCreation;
	ShipControl shipControl;
	SquadronControl squadronControl;



	// Use this for initialization
	void Start () {
		//try to make a dict with scripts inheriting from same base
		createLine = GetComponent<CreateLine> ();
		pointCreation = GetComponent<PointCreation> ();
		shipControl = GetComponent<ShipControl> ();
		squadronControl = GetComponent<SquadronControl> ();
		//shipControl.enabled = false;
		//createLine.Disable ();
		//pointCreation.Disable ();
		SetState("Main");
	}

	public void SetState(string s){
		status = s;
		/**/
		mainUI.SetActive (false);
		if (status == "CustomLine")
			createLine.Enable ();
		else if (status == "CustomPoint") {
			pointCreation.enabled = true;
			pointCreation.Enable ();
		}
		else if (status == "SquadronControl")
			squadronControl.Enable ();
		else if (status == "ShipControl")
			shipControl.Enable ();
		else if (status == "Main") {
			mainUI.SetActive (true);
			/*createLine.Disable ();
			pointCreation.Disable ();
			shipControl.Disable ();*/
		}
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log ("STATUS:" + status);
		//Debug.Log ("OLD STATUS:" + oldStatus);
		/*if (status != oldStatus) {
			oldStatus = status;
			SetState (status);
		}*/
	}
}

/*public enum Status{
	Main,
	CustomPoint,
	CustomLine,
}*/
