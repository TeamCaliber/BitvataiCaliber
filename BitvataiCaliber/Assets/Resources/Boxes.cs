using UnityEngine;
using System.Collections.Generic;


public struct boxes{

	public GameObject left;
	public GameObject right;
	public GameObject down;
	public GameObject top;
}
public class Boxes : MonoBehaviour {

	public boxes box;
	public bool isPlayerOnthis = false;
	public List<GameObject> boxList = new List<GameObject>();
	public bool Clickable;
	// Use this for initialization
	void Start () {	
	
		if(boxList.Count < 4)
		{
			boxList.Add(box.left);
			boxList.Add(box.top);
			boxList.Add(box.down);
			boxList.Add(box.right);
			
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if(isPlayerOnthis == true)
		{
			foreach (GameObject boxes in boxList)
			{	if(boxes!=null)
				boxes.GetComponent<Boxes>().Clickable = true;
			}
		
		}
		
		if (Input.GetButtonDown("Fire1")) {
		Debug.Log("asD");
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);
			if (Physics.Raycast(Input.mousePosition,fwd,out hit))
			{
					Debug.Log(hit.transform.name);
			}
			
				
				
		}
	}
}
	