using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame_1Player()
    {
        SceneManager.LoadScene("Game_1Player");
        ScoreController.scorePlayer1 = 0;
        ScoreController.scorePlayer2 = 0;
    }
    public void StartGame_2Players()
    {
        SceneManager.LoadScene("Game_2Players");
        ScoreController.scorePlayer1 = 0;
        ScoreController.scorePlayer2 = 0;
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Restart()
    {
        if (ScoreController.scene == "Game_1Player")
        {
            SceneManager.LoadScene("Game_1Player");
        }
        else if (ScoreController.scene == "Game_2Players")
        {
            SceneManager.LoadScene("Game_2Players");
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MainMenuChoosePlayer()
    {
        SceneManager.LoadScene("MainMenu_ChoosePlayer");
    }

}
