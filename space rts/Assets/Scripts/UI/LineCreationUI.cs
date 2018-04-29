using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineCreationUI : MonoBehaviour {

	public Text text;
	public GameObject line;

	int pointCount;
	string[] messages;

	// Use this for initialization
	void Start () {
		pointCount = 0;
		messages = new string[2]{ "Select point A", "Select point B" };

	}

	public void SetMessage(int index){
		text.text = messages[index];
	}

	public void Deselect(int index){
		pointCount = 0;
		text.text = messages[pointCount];
	}

	public void Cancel(){
		gameObject.SetActive (false);	
	}

	// Update is called once per frame
	void Update () {

	}
}
