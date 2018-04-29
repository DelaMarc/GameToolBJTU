using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour {

	public GameObject fighterPrefab;
	public int numFighters = 6;
	public GameObject[] allFighters;
	public Vector3 flyLimits = new Vector3 (10, 10, 10);
	public Vector3 goalPos;

	[Header("")]
	[Range(0.0f, 5.0f)]
	public float minSpeed;
	[Range(0.0f, 5.0f)]
	public float maxSpeed;
	[Range(1.0f, 10.0f)]
	public float neighbourDistance;
	[Range(0.0f, 5.0f)]
	public float rotationSpeed;

	// rendre les vaisseaux instantiables depuis l'éditeur
	void Start () {
		goalPos = this.transform.position;
		if (allFighters[0] == null) {
			GenerateFlock ();
		}
	}

	public void GenerateFlock(){
		int i;
		Vector3 pos;

		RemoveChilds ();
		allFighters = new GameObject[numFighters];
		for (i = 0; i < numFighters; ++i) {
			pos = this.transform.position + new Vector3 (Random.Range(-flyLimits.x, flyLimits.x),
				Random.Range(-flyLimits.y, flyLimits.y),
				Random.Range(-flyLimits.z, flyLimits.z));
			allFighters [i] = (GameObject)Instantiate (fighterPrefab, pos, Quaternion.identity);
			allFighters [i].transform.parent = this.transform.parent;
			allFighters [i].GetComponent<Flock> ().manager = this;
		}
	}

	public void RemoveFlock(){
		int i;

		for (i = 0; i < numFighters; ++i){
			DestroyImmediate (allFighters [i]);
		}
		RemoveChilds ();
	}

	void RemoveChilds(){
		List<GameObject> childs;

		childs = new List<GameObject> ();
		foreach (Transform child in this.transform.parent) {
			if (child.name != this.name) {
				childs.Add (child.gameObject);
			}
		}
		childs.ForEach (child => DestroyImmediate(child));
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, 100) < 10) {
			goalPos = this.transform.position + new Vector3 (Random.Range(-flyLimits.x, flyLimits.x),
				Random.Range(-flyLimits.y, flyLimits.y),
				Random.Range(-flyLimits.z, flyLimits.z));
		}
	}
}
