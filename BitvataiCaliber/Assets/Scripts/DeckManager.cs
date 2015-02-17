using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DeckManager : MonoBehaviour {
	
	public TextAsset MoneyCards;
	public TextAsset TroopCards;
	public TextAsset ShipCards;
	public PlayerManager Players;
	public List<Ship> ShipDeck;
	public List<Troop> TroopDeck;
	public List<Money> MoneyDeck;

	public void ShuffleAll(){
		List<Ship> ships = ShipDeck;
		ShipDeck = new List<Ship>();

	}

	// Use this for initialization
	void Start () {
		MoneyDeck = new List<Money>();
		ShipDeck = new List<Ship>();
		TroopDeck = new List<Troop>();

		string[,] moneyGrid = SplitCsvGrid(MoneyCards.text);		
		List<string[]> moneyText = OutputGrid(moneyGrid); 
		for(int i = 1; i < moneyText.Count; i++){
			List<string[]> text = moneyText;
			int count = int.Parse(text[i][1]);
			for(int j = 0; j<count; j++){
				Money newMoney = new Money();
				newMoney.Amount = int.Parse (text[i][0]);
				newMoney.Type = (text[i][2]=="1")? Money.MoneyType.Risky: Money.MoneyType.Consistent;
				MoneyDeck.Add(newMoney);
			}
		}
		
		string[,] troopGrid = SplitCsvGrid(TroopCards.text);		
		List<string[]> troopText = OutputGrid(troopGrid); 
		for(int i = 1; i < troopText.Count; i++){
			List<string[]> text = troopText;
			int count = int.Parse(text[i][1]);
			for(int j = 0; j<count; j++){
				Troop newTroop = new Troop();
				newTroop.InitializeTroop(int.Parse(text[i][0]));
				TroopDeck.Add(newTroop);
			}
		}

		string[,] shipGrid = SplitCsvGrid(ShipCards.text);		
		List<string[]> shipText = OutputGrid(shipGrid); 
		for(int i = 0; i < shipText.Count; i++){
			List<string[]> text = shipText;
			int count=0;
			try{count = int.Parse(text[i][6]);}
			catch(System.Exception e){continue;}
			for(int j = 3; j<count; j++){
				Ship newShip = new Ship();
				newShip.Name = text[i][8];
				newShip.Admiral = "Troop";
				newShip.MinTroops = int.Parse(text[i][2]);
				newShip.Force = int.Parse(text[i][3]);
				newShip.MoraleDamage = int.Parse(text[i][4]);
				newShip.Cost = int.Parse(text[i][5]);
				ShipDeck.Add(newShip);
			}
		}
	}
	void Awake(){Players = GameObject.FindWithTag("PlayerManager").GetComponent<PlayerManager>();}
	/// <summary>
	/// READING CSVs and returning Lists of String arrays representing the csvs as tables
	/// </summary>
	/// <returns>The grid.</returns>
	/// <param name="grid">Grid.</param>

	// outputs the content of a 2D array, useful for checking the importer
	static public List<string[]> OutputGrid(string[,] grid)
	{
		List<string[]> GridArray = new List<string[]>();
		for (int y = 0; y < grid.GetUpperBound(1); y++) {	
			string[] array = new string[5];
			for (int x = 0; x < 3; x++) {
				array[x] = grid[x,y]; 
			}
			GridArray.Add(array);
		}
		return GridArray;
	}
	
	// splits a CSV file into a 2D string array
	static public string[,] SplitCsvGrid(string csvText)
	{
		string[] lines = csvText.Split("\n"[0]); 
		
		// finds the max width of row
		int width = 0; 
		for (int i = 0; i < lines.Length; i++)
		{
			string[] row = SplitCsvLine( lines[i] ); 
			width = Mathf.Max(width, row.Length); 
		}
		
		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1]; 
		for (int y = 0; y < lines.Length; y++)
		{
			string[] row = SplitCsvLine( lines[y] ); 
			for (int x = 0; x < row.Length; x++) 
			{
				outputGrid[x,y] = row[x]; 
				
				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				outputGrid[x,y] = outputGrid[x,y].Replace("\"\"", "\"");
			}
		}
		
		return outputGrid; 
	}
	
	// splits a CSV row 
	static public string[] SplitCsvLine(string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
		                                                                                                    @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)", 
		                                                                                                    System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
		        select m.Groups[1].Value).ToArray();
	}
}
