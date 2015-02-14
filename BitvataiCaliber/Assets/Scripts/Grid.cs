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
	public int [] a = new int[5];
	
	// Use this for initialization
	void Start () {
		Instantiate (japPlayer);
		Instantiate (rusPlayer);
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
				cube.transform.parent = this.transform;
				cube.renderer.material.color = new Color(Random.Range (0f,10f) / 10, Random.Range (0f,10f) / 10, Random.Range (0f,10f) / 10);
				position[i,j]= cube;
				cubeNum++;
			}
			y-=2;
			x=-6;
			
		}
		
		Debug.Log (position.Length);
	}
}
