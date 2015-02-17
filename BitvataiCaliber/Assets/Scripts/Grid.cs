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
	public GameObject PlayerManagerPrefab;
	public GameObject DeckManagerPrefab;
	public GameObject TurnManagerPrefab;
	PlayerManager Players;

	public bool check1;
	public List<GameObject> neighborNodes = new List<GameObject>();
	// Use this for initialization
	void Start () {
		Instantiate (japPlayer);
		Instantiate (rusPlayer);
		Players = Instantiate (PlayerManagerPrefab) as PlayerManager;
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
				cube.AddComponent("BoxCollider");
			//	cube.tag = "Box";
				position[i,j] = cube;

				cubeNum++;
			}
			y-=2;
			x=-6;
			
		}
		
		MapNodes();
	}
	
	void MapNodes()
	{
	for (int i = 0; i < 6; i++) {
		
			for (int j = 0; j < 5; j++) {
				
				if((i-1) >=0)
				{
				position[i,j].GetComponent<Boxes>().box.top = position[i-1,j];
				if(position[i,j].name== "Box1")
				Debug.Log("left" + position[i-1,j]);
				}
				
			
				if((i+1) <=5)
				{
				
				position[i,j].GetComponent<Boxes>().box.down = position[i+1,j];

				}
				
			
				if((j-1) >=0)
				{
				
				position[i,j].GetComponent<Boxes>().box.left = position[i,j-1];
					
				}
				
			
				if((j+1) <=4)
				{
					try{
						position[i,j].GetComponent<Boxes>().box.right = position[i,j+1];
					}
					catch(System.IndexOutOfRangeException e){
						
					}
				}
			}
			
			
			
	}
	
	
	}

}
