using UnityEngine;
using System.Collections;

public class Updater : MonoBehaviour {

	public PlayerManager Players;
	// Use this for initialization
	void Start () {
		Players = (GameObject.FindWithTag ("PlayerManager")).GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		UpdateValues ();
	}
	
	void UpdateValues(){
		Debug.Log ("VALUES");	

	}
}
