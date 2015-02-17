using UnityEngine;
using System.Collections;
using UnityEditor;

public class TurnManager : MonoBehaviour {

    // All game states
    public enum STATE { LOADING, UPKEEP, ACTION, MOVE, GAMEUPKEEP, ENDGAME, RESETGAME }
    // Number of players
    public enum PLAYER { ONE, TWO}
	public PlayerData[] Player;
    public STATE CurrentState;
    public PLAYER CurrentPlayer;
	public Grid Graph;
	public DeckManager Decks;
	public PlayerManager Players;
	public bool Started = false;
    int TurnCount = 1;
    public int MaxTurnCount = 15;


	// Use this for initialization
	void Start ()
    {
		Player=new PlayerData[2];
		int i = 0;
		i = Random.Range (0, 1);
		Player [i] = Players.Japan;
		Player [(i + 1) % 2] = Players.Russia;

        ResetGame();
        PrintDebugLog();    
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if(Input.GetKeyDown(KeyCode.Space)) ChangeState();
		if (!Started) {
						return;
		}
        switch (CurrentState)
        {
            case STATE.UPKEEP:
                PrintDebugLog();  
				ChangeState();// temporary until implemented
                break;
            
            case STATE.ACTION:
                PrintDebugLog();    
				ChangeState();// temporary until implemented
                break;
            
            case STATE.MOVE:
				ChangeState();// temporary until implemented
                PrintDebugLog();    
                break;

            case STATE.GAMEUPKEEP:
                PrintDebugLog();    
                // This state executes only in one frame.
                // It changes the current player
                // Increases turn count if both players have played.
                // It calls change state to automaticaly go to the next state.

                if (CurrentPlayer == PLAYER.TWO) TurnCount++;
                ChangePlayer();
                ChangeState();
                
            // Checks if the game is over
                if (TurnCount > MaxTurnCount) 
					CurrentState = STATE.ENDGAME;
                break;
            
            case STATE.ENDGAME:
                // This states executes only in one frame .
                // It Ends the game
                PrintDebugLog();

                EditorUtility.DisplayDialog("End game!","The game is over!","Close");
                CurrentState = STATE.RESETGAME;

                break;

            case STATE.RESETGAME:
                // This states executes only in one frame .
                // It may be used to reset the game.

                //ResetGame();
                PrintDebugLog();

                break;

            default:
                Debug.Log("Game Awaiting Content to Load...");
                
                break;
        }
	
	}

    // This function changes between the game states.
    void ChangeState()
    {
        switch (CurrentState)
        {
            case STATE.UPKEEP:
			    CurrentState = STATE.ACTION;
                break;

            case STATE.ACTION:
                CurrentState = STATE.MOVE;
                break;

            case STATE.MOVE:
                CurrentState = STATE.GAMEUPKEEP;
                break;

            case STATE.GAMEUPKEEP:
                if (TurnCount == 1) 
                    CurrentState = STATE.ACTION;
                else
                    CurrentState = STATE.UPKEEP;
                break;

            case STATE.ENDGAME:
                CurrentState = STATE.RESETGAME;
                break;
        }
    }
    // This function changes between the tywo players.
    void ChangePlayer()
    {
        if (CurrentPlayer == PLAYER.ONE) 
			CurrentPlayer = PLAYER.TWO;
        else 
			CurrentPlayer = PLAYER.ONE;
    }

    // Prints on the log the Current player, Current State and turn count for debbuging issues.
    void PrintDebugLog()
    {
        Debug.Log(CurrentPlayer);
        Debug.Log(CurrentState);
        Debug.Log(TurnCount);
    }

    // Resets the game back to its original state.
    public void ResetGame()
    {
		CurrentState = STATE.ACTION;
        CurrentPlayer = PLAYER.ONE;
        TurnCount = 1;
    }

	public void InitiateGame(){
		Started = true;
	}
}
