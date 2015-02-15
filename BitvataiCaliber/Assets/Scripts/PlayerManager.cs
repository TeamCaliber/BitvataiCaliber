using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

	public DeckManager Decks;

	public PlayerData Japan;
	public GameObject JapanPiece;
	public PlayerData Russia;
	public GameObject RussiaPiece;
	// Use this for initialization
	void Start () {
		
		Decks = GameObject.FindWithTag("DeckManager").GetComponent<DeckManager>();
		try{
			JapanPiece = GameObject.FindWithTag("JapanPiece");
		}
		catch(UnityException e){
		}
		// Create Player Object
		if(JapanPiece==null){
			JapanPiece=new GameObject();
		}
		JapanPiece.AddComponent<PlayerData>();
		Japan = JapanPiece.GetComponent<PlayerData>();
		
		Japan.OwnedShips = new List<Ship>();
		Japan.TroopCards = new List<Troop>();
		Ship Mikasa = Japan.AddShip(8, 8, 0, 8); //AddShip(int force, float moraleDmg, int cost, int minimumTroops)
		Mikasa.Name = "Mikasa";
		Mikasa.Admiral = "Togo Heihashiro";
		Japan.AddTroopCard(8).AssignToShip(Mikasa); //AddTroopCard(int numberOfTroops) + AssignToShip( Ship ShipToAssignTroopCardTo )
		Japan.Morale = 75;
		Japan.CurrentMoney = 5;
		// generate Japanese Player GameObject
	
		try{
			RussiaPiece = GameObject.FindWithTag("RussiaPiece");
		}
		catch(UnityException e){
		}
		// Create Player Object
		if(RussiaPiece==null){
			RussiaPiece=new GameObject();
		}
		RussiaPiece.AddComponent<PlayerData>();
		Russia = RussiaPiece.GetComponent<PlayerData>();
		Russia.OwnedShips = new List<Ship>();
		Russia.TroopCards = new List<Troop>();
		Ship Suvonov = Russia.AddShip(4, 4, 0, 4); //AddShip(int force, float moraleDmg, int cost, int minimumTroops)
		Suvonov.Name = "Knyaz Surorov";
		Suvonov.Admiral = "Zinovy Rozheshensky";
		Russia.AddTroopCard(4).AssignToShip(Suvonov); //AddTroopCard(int numberOfTroops) + AssignToShip( Ship ShipToAssignTroopCardTo )
		Russia.AddTroopCard(6);
		Russia.Morale = 70;
		Russia.CurrentMoney = 5;
		// generate Russian Player GameObject

		PrintRussia();
		PrintJapan();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void PrintRussia(){
		foreach(Ship s in Russia.OwnedShips){
			Debug.Log("Suvorov Instantiated!" + " Force of: " + s.Force + "! " + ((s.Manned)? "MANNED!":"UNMANNED!"));
		}
		foreach(Troop t in Russia.TroopCards){
			Debug.Log("Russian Troop Card with " + t.Force + " Troops!");
		}
		Debug.Log("Russian morale at: " + Russia.Morale + "% Morale");
		Debug.Log("Russian Base Force at: " + Russia.GetBaseForce() + " Force");
		Debug.Log("Russian Effective Force at: " + Russia.CalculateForce() + " Force");
	}

	void PrintJapan(){
		foreach(Ship s in Japan.OwnedShips){
			Debug.Log("Mikasa Instantiated!" + " Force of: " + s.Force + "! " + ((s.Manned)? "MANNED!":"UNMANNED!"));
		}
		foreach(Troop t in Japan.TroopCards){
			Debug.Log("Japanese Troop Card with " + t.Force + " Troops!");
		}
		Debug.Log("Japanese morale at: " + Japan.Morale + "% Morale");
		Debug.Log("Japanese Base Force at: " + Japan.GetBaseForce() + " Force");
		Debug.Log("Japanese Effective Force at: " + Japan.CalculateForce() + " Force");
	}
}
