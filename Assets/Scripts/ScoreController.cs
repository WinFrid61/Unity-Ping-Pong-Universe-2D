using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    internal static int scorePlayer1 = 0;
    internal static int scorePlayer2 = 0;
    internal static int SceneID;
    internal static string scene;

    public GameObject Player1Score;
    public GameObject Player2Score;

    public int goalToWin;

    private void Update()
    {
        if (scorePlayer1 >= this.goalToWin && SceneManager.GetActiveScene().name == "Game_1Player") {
            Debug.Log("Player 1 won!");
            SceneID = 1;
            scene = "Game_1Player";
            SceneManager.LoadScene("GameOver");
        }
        else if (scorePlayer2 >= this.goalToWin && SceneManager.GetActiveScene().name == "Game_1Player")
        {
            Debug.Log("Player 2 won!");
            SceneID = 2;
            scene = "Game_1Player";
            SceneManager.LoadScene("GameOver");
        }
        else if (scorePlayer1 >= this.goalToWin && SceneManager.GetActiveScene().name == "Game_2Players")
        {
            Debug.Log("Player 1 won!");
            SceneID = 3;
            scene = "Game_2Players";
            SceneManager.LoadScene("GameOver");
        }
        else if (scorePlayer2 >= this.goalToWin && SceneManager.GetActiveScene().name == "Game_2Players")
        {
            Debug.Log("Player 2 won!");
            SceneID = 4;
            scene = "Game_2Players";
            SceneManager.LoadScene("GameOver");
        }
    }

    private void FixedUpdate()
    {

        Text UIPlayer1Score = Player1Score.GetComponent<Text>();
        UIPlayer1Score.text = scorePlayer1.ToString();

        Text UIPlayer2Score = Player2Score.GetComponent<Text>();
        UIPlayer2Score.text = scorePlayer2.ToString();
    }

    public void GoalPlayer1()
    {
        scorePlayer1++;
    }
    public void GoalPlayer2()
    {
        scorePlayer2++;
    }
}
