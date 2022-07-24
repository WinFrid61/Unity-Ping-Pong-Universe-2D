using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject Advise;
    public ScoreController ScoreController;

    private void Start()
    {
        GameOverChange();
    }
    void GameOverChange()
    {
        Text UIGameOverText = this.GameOverText.GetComponent<Text>();
        Text UIAdvise = this.Advise.GetComponent<Text>();
        if (ScoreController.SceneID == 1) 
        {
            UIGameOverText.text = "You won with score <color=blue>" + ScoreController.scorePlayer1 + "</color>:<color=green>" + ScoreController.scorePlayer2 + "</color>!";
            UIAdvise.text = "But the bot just warmed up..\nOne more? ツ";
            ScoreController.scorePlayer1 = 0;
            ScoreController.scorePlayer2 = 0;
        }
        else if (ScoreController.SceneID == 2)
        {
            UIGameOverText.text = "You lost with score <color=blue>" + ScoreController.scorePlayer1 + "</color>:<color=green>" + ScoreController.scorePlayer2 + "</color>!";
            UIAdvise.text = "You probably did your best!\nOne more to improve your skill? ツ";
            ScoreController.scorePlayer1 = 0;
            ScoreController.scorePlayer2 = 0;
        }
        else if (ScoreController.SceneID == 3)
        {
            UIGameOverText.text = "<color=blue>Player 1</color> wins! Score - <color=blue>" + ScoreController.scorePlayer1 + "</color>:<color=green>" + ScoreController.scorePlayer2 + "</color>";
            UIAdvise.text = "Better luck next time, <color=green>Player 2</color> ツ";
            ScoreController.scorePlayer1 = 0;
            ScoreController.scorePlayer2 = 0;
        }
        else if (ScoreController.SceneID == 4)
        {
            UIGameOverText.text = "<color=green>Player 2</color> wins! Score - <color=blue>" + ScoreController.scorePlayer1 + "</color>:<color=green>" + ScoreController.scorePlayer2 + "</color>";
            UIAdvise.text = "Better luck next time, <color=blue>Player 1</color> ツ";
            ScoreController.scorePlayer1 = 0;
            ScoreController.scorePlayer2 = 0;
        }
    }
}
