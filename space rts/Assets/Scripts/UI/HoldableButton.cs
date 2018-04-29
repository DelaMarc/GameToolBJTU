using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoldableButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	CustomPointUI ui;
	public Vector3 direction;
	//bool pressed;

	// Use this for initialization
	void Start () {
		ui = FindObjectOfType<CustomPointUI> ();
	}

	public void OnPointerDown(PointerEventData eventData){
		ui.SetupHold (direction);
	}

	public void OnPointerUp(PointerEventData eventData){
		ui.unsetHold ();
	}
}
