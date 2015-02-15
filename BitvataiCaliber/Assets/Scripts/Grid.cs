using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
	public int x,y;
	public float check;
	public int cubeNum;
	public GameObject japPlayer;
	public GameObject rusPlayer;
	public GameObject[,] position = new GameObject [6,5];
//	public List<GameObject> position = new List<GameObject>();
	public int [] a = new int[5];
	public GameObject PlayerManager;
	public bool check1;
	
	// Use this for initialization
	void Start () {
		Instantiate (japPlayer);
		Instantiate (rusPlayer);
		Instantiate (PlayerManager);
		japPlayer.transform.position = new Vector3 (-4f, 7f, -1f);
		rusPlayer.transform.position = new Vector3 (-4f, -3f, -1f);
		CreateWorld ();
	}
	
	// Update is called once per frame
	void Update () {

	
	}
	
	void CreateWorld()
	{
		
		for (int i = 0; i <6; i++) {
			
			for (int j = 0; j < 5; j++) {

				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.name = "Box"+ cubeNum;
				cube.transform.position = new Vector3 (x+=2,y,0);
				cube.renderer.material.color = new Color(Random.Range (0f,10f) / 10, Random.Range (0f,10f) / 10, Random.Range (0f,10f) / 10);
				cube.AddComponent("Boxes");
				position[i,j] = cube;

				cubeNum++;
			}
			y-=2;
			x=-6;
			
		}
		CurrentPosis();

	}
	void CurrentPosis()
	{
		Debug.Log (position.Length);
		foreach (GameObject boxes in position) {
			Debug.Log ("Hello");
			if (this.transform.position == boxes.transform.position) {
				Debug.Log ("Gotcha" + boxes.transform.position);
			}
		}
	}

}
