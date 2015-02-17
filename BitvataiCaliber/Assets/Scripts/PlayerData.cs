using UnityEngine;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
	public enum Action {
		Recruit,
		Extort,
		Gift,
		NONE
	}
	public PlayerManager PM;
	public TurnManager Turns;
	public Action CurrentAction;
	public bool MyTurn = false;
    public PlayerData OpponentData; // not set up
    public List<Ship> OwnedShips;
    public List<Troop> TroopCards;
    public int Morale = 0;
    public int CurrentMoney = 0;

    /// <summary>
    /// ADDING ALL OBJECTS TO THE PLAYER
    /// </summary>
    /// <returns>The troop card.</returns>
    public Troop AddTroopCard(int numberOfTroops)
    {
        Troop troop = (new Troop()).InitializeTroop(numberOfTroops);
        TroopCards.Add(troop);
        return troop;
    }
    public Ship AddShip(int force, float moraleDmg, int cost, int minTroops)
    {
        Ship ship = (new Ship()).InitializeShip(force, moraleDmg, cost, minTroops);
        OwnedShips.Add(ship);
        return ship;
    }
    public int AddMoney(Money money)
    {
        CurrentMoney += money.Amount;
        return money.Amount;
    }

    /// <summary>
    /// CALCULATIONS
    /// </summary>
    /// <returns>The force.</returns>
    public float CalculateForce()
    {
        int force = GetBaseForce();
        int morale = GetMorale();
        return ((float)(force)) * (((float)morale) / 100);
    }
    public int GetBaseForce()
    {
        int force = 0;
        foreach (Troop t in TroopCards)
        {
            force += t.Force;
        }
        foreach (Ship s in OwnedShips)
        {
            if (s.Manned)
            {
                force += s.Force;
            }
            else
                Debug.Log("UNMANNED!");
        }
        return force;
    }
    // Getter Functions
    public int GetMorale()
    {
        return Morale;
    }

    public int GetMoney()
    {
        return CurrentMoney;
    }
    public int GetTroops()
    {   
        // Calculate Troops total by reading teh cards.
        // 1 Troop = 1 Force.
        int CurrentTroops = 0;
        foreach (Troop t in TroopCards){
            CurrentTroops += t.Force;
        }
        return CurrentTroops;
    }

    // Used by the UI to set the Different Actions.
    public void ChooseAction (int ActionType)
    {
        switch (ActionType)
        {
            case 0:
                CurrentAction = Action.Recruit;
                Debug.Log("Recruit");
                break;
            case 1:
                CurrentAction = Action.Extort;
                Debug.Log("Extort");
                break;
            case 2:
                CurrentAction = Action.Gift;
                Debug.Log("Gift");
                break;
            case 3:
                CurrentAction = Action.NONE;
                Debug.Log("NONE");
                break;
            default:
                Debug.Log("Invalid Action");
                break;

        }
    }
}
