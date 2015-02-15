using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    // Load the game scene.
    public void StartGame()
    {
        Application.LoadLevel("GameScene");
    }

    // Quit the game scene.
    public void ExitGame()
    {
        Application.Quit();
    }
        
}
