using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Moves : MonoBehaviour {
	
	public Grid grid;
	public List<GameObject> neighborNodes = new List<GameObject>();
	public GameObject tempObject;
	public GameObject tempObject1;
	// Use this for initialization
	void Start () {
		grid = GameObject.Find ("Plane").GetComponent<Grid> ();

	}
	
	// Update is called once per frame
	void Update () {

		CurrentPosis();

	}

	void CurrentPosis()
	{
		foreach (GameObject boxes in grid.position) {

			if (this.transform.position.x == boxes.transform.position.x && this.transform.position.y == boxes.transform.position.y) {
				tempObject = boxes;
				Debug.Log (tempObject.name);

			}
		}

	}

	void FindPossibleMoves()
	{


	}
}
