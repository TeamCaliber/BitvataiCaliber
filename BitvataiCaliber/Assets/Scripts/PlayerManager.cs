using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

	public DeckManager Decks;
	public TurnManager Turns;

	public PlayerData Japan;
	public GameObject JapanPiece;
	public PlayerData Russia;
	public GameObject RussiaPiece;

	//Manager Prefab Variables
	public GameObject DMPrefab;
	public GameObject TurnPrefab;
	
    // UI Variables
    // Japan:
    public Text JpnMoney;
    public Text JpnTroops;
    public Text JpnMorale;
    public Text JpnForce;

    // Russia:
    public Text RusMoney;
    public Text RusTroops;
    public Text RusMorale;
    public Text RusForce;
    
    
    // Use this for initialization
	void Start () {
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
		Japan.PM = this;
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
		Russia.PM = this;
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

		//PrintRussia();
		//PrintJapan();
	}
	void Awake(){
		Decks = (Instantiate(DMPrefab) as GameObject).GetComponent<DeckManager>();
		Turns = (Instantiate(TurnPrefab) as GameObject).GetComponent<TurnManager>();
		Turns.Decks = Decks;
		Turns.Players = this;
		Turns.Graph = GameObject.FindWithTag("Grid").GetComponent<Grid>();
		Turns.InitiateGame();
	}
	// Update is called once per frame
	void Update () {
		try{
	        // Updates UI elements
	        //Japan:
	        JpnMoney.text = Japan.GetMoney().ToString();
	        JpnTroops.text = Japan.GetTroops().ToString();
	        JpnMorale.text = Japan.GetMorale().ToString();
	        JpnForce.text = Japan.CalculateForce().ToString();

	        // Russia:
	        RusMoney.text = Russia.GetMoney().ToString();
	        RusTroops.text = Russia.GetTroops().ToString();
	        RusMorale.text = Russia.GetMorale().ToString();
	        RusForce.text = Russia.CalculateForce().ToString();
		}
		catch(System.Exception e){
		}
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
