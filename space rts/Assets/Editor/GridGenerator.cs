using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class GridGenerator : Editor {
	Grid grid;

	public override void OnInspectorGUI(){
		//displays the public variables
		base.OnInspectorGUI ();
		if (GUILayout.Button ("Generate")) {
			grid = (Grid)target;
			grid.CreateGrid ();
			grid.CreateGrid ();
		}

		if (GUILayout.Button ("Reset")) {
			grid = (Grid)target;
			grid.Reset ();
		}
	}



}
