using UnityEngine;
using System.Collections;

public class DeckUI : MonoBehaviour {

    public GameObject PlayerManagerObj;
    PlayerManager PlayerManagerScr;

    public GameObject DeckManagerObj;
    DeckManager DeckManagerScr;

	// Use this for initialization
	void Start () {
        try
        {
            // Gets the Player Manager Script
            PlayerManagerObj = GameObject.FindWithTag("PlayerManager");
            PlayerManagerScr = PlayerManagerObj.GetComponent<PlayerManager>();

            DeckManagerObj = GameObject.FindWithTag("DeckManager");
            DeckManagerScr = DeckManagerObj.GetComponent<DeckManager>();
            
        }
        catch (UnityException e)
        {
        }
	
	}
	
	// Draw from the Japanese Troop Deck
	public void DrawTroopJapan()
    {
        PlayerManagerScr.Japan.AddTroopCard(DeckManagerScr.getTopTroopCard().Force);
	}

    // Draw from the Japanese Money Deck
    public void DrawMoneyJapan()
    {
        PlayerManagerScr.Japan.AddMoney(DeckManagerScr.getTopMoneyCard());
    }

    // Draw from the Japanese Ship Deck
    public void DrawShipJapan()
    {
        Ship ShipCard = DeckManagerScr.getTopShipCard();
        PlayerManagerScr.Japan.AddShip(ShipCard.Force,ShipCard.MoraleDamage,ShipCard.Cost, ShipCard.MinTroops);
    }


    // Draw from the Russia Troop Deck
    public void DrawTroopRussia()
    {
        PlayerManagerScr.Russia.AddTroopCard(DeckManagerScr.getTopTroopCard().Force);
    }

    // Draw from the Russia Money Deck
    public void DrawMoneyRussia()
    {
        PlayerManagerScr.Russia.AddMoney(DeckManagerScr.getTopMoneyCard());
    }

    // Draw from the Russia Ship Deck
    public void DrawShipRussia()
    {
        Ship ShipCard = DeckManagerScr.getTopShipCard();
        PlayerManagerScr.Russia.AddShip(ShipCard.Force, ShipCard.MoraleDamage, ShipCard.Cost, ShipCard.MinTroops);
    }
}
