using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridModel")]
public class GridData : ScriptableObject {

	public int scale;
	public int widthSpace;
	public int lengthSpace;
	public int depthSpace;
	public GameObject mapPoint;
	public GameObject line;
}
