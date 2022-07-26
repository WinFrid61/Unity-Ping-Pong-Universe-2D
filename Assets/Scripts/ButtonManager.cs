using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame_1Player()
    {
        Debug.Log("New game (1 Player) started!");
        SceneManager.LoadScene("Game_1Player");
        ScoreController.scorePlayer1 = 0;
        ScoreController.scorePlayer2 = 0;
    }
    public void StartGame_2Players()
    {
        Debug.Log("New game (2 Players) started!");
        SceneManager.LoadScene("Game_2Players");
        ScoreController.scorePlayer1 = 0;
        ScoreController.scorePlayer2 = 0;
    }
    public void Settings()
    {
        Debug.Log("Settings window opened (Button)");
        SceneManager.LoadScene("Settings");
    }
    public void Exit()
    {
        Debug.Log("Closing the game.. (Button)");
        Application.Quit();
    }

    public void Help()
    {
        Debug.Log("Help window opened (Button)");
        SceneManager.LoadScene("Help");
    }

    public void Restart()
    {
        if (ScoreController.scene == "Game_1Player")
        {
            Debug.Log("Restarting the game (1 Player)..");
            SceneManager.LoadScene("Game_1Player");
        }
        else if (ScoreController.scene == "Game_2Players")
        {
            Debug.Log("Restarting the game (2 Players)..");
            SceneManager.LoadScene("Game_2Players");
        }
    }
    public void MainMenu()
    {
        Debug.Log("MainMenu window opened (Button)");
        SceneManager.LoadScene("MainMenu");
    }

}
