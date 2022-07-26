using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//script which answers for goaltowin achievement
//after the game loads gameover scene with result and some models with correct animation
//also increases player's score if he hits left/right wall;
public class ScoreController : MonoBehaviour
{
    internal static int scorePlayer1 = 0;
    internal static int scorePlayer2 = 0;
    internal static int SceneID;
    internal static string scene;

    [SerializeField]
    private GameObject GoldenRacketLeft;
    [SerializeField]
    private GameObject GoldenRacketRight;
    [SerializeField]
    private GameObject Player1Score;
    [SerializeField]
    private GameObject Player2Score;

    [SerializeField]
    private int goalToWin;

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

        if (scorePlayer1 > scorePlayer2)
        {
            GoldenRacketLeft.SetActive(true);
            GoldenRacketRight.SetActive(false);
        }
        else if (scorePlayer1 < scorePlayer2)
        {
            GoldenRacketLeft.SetActive(false);
            GoldenRacketRight.SetActive(true);
        }
        else
        {
            GoldenRacketLeft.SetActive(false);
            GoldenRacketRight.SetActive(false);
        }
    }

    private void FixedUpdate()
    {

        Text UIPlayer1Score = Player1Score.GetComponent<Text>();
        UIPlayer1Score.text = scorePlayer1.ToString();

        Text UIPlayer2Score = Player2Score.GetComponent<Text>();
        UIPlayer2Score.text = scorePlayer2.ToString();
    }

    //method to increase player's 1 score
    public void GoalPlayer1()
    {
        scorePlayer1++;
    }
    //method to increase player's 2 score
    public void GoalPlayer2()
    {
        scorePlayer2++;
    }
}
