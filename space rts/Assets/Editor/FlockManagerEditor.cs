using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FlockManager))]
public class FlockManagerEditor : Editor {

	FlockManager flockManager;

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		if (GUILayout.Button("Generate")){
			flockManager = (FlockManager)target;
			flockManager.GenerateFlock ();
		}
		if (GUILayout.Button("Reset")){
			flockManager = (FlockManager)target;
			flockManager.RemoveFlock ();
		}
	}
}
