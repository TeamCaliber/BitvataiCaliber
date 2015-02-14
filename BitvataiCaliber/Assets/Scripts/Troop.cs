using UnityEngine;
using System.Collections;

public class Troop {
	
	public bool Allocated = false;
	public Ship MannedShip;
	public int Force;
	public GameObject Card;
	// Use this for initialization
	public Troop InitializeTroop(int numberOfTroops){
		Force = numberOfTroops;
		return this;
	}
	public void AssignToShip(Ship ship){
		MannedShip = ship;
		Allocated = true;
		MannedShip.TroopsAllocated += Force;
		if(MannedShip.TroopsAllocated>=MannedShip.MinTroops){
			MannedShip.Manned = true;
		}
	}
}
