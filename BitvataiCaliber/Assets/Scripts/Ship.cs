using UnityEngine;
using System.Collections;

public class Ship {

	public bool Manned = false;
	public int Force;
	public float MoraleDamage;
	public int Cost;
	public GameObject Card;
	public int TroopsAllocated;
	public bool Owned = false;
	public int MinTroops;
	public string Name;
	public string Admiral;

	public Ship InitializeShip(int force, float moraleDmg, int cost, int minimumTroops){
		Force = force;
		MoraleDamage = moraleDmg;
		Cost = cost;
		MinTroops = minimumTroops;
		return this;
	}
}
