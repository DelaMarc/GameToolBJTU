using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipControlUI : MonoBehaviour {

	public Text position;
	public Text rotation;


	// Use this for initialization
	void Start () {
		position.text = "";
		rotation.text = "";
	}

	public void Select(){
		
		position.enabled = true;
		rotation.enabled = true;
	}

	public void Deselect(){
		position.enabled = true;
		rotation.enabled = true;
	}

	public void UpdateUI(Transform ship){
		position.text = "Position:" + ship.position;
		rotation.text = "Rotation:" + ship.rotation;
	}
		
}
