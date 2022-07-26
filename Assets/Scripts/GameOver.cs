using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for the gameover
public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Animator animatorFoxie;
    [SerializeField]
    private Animator animatorKira;
    [SerializeField]
    public GameObject GoldenRacketLeft;
    [SerializeField]
    private GameObject GoldenRacketRight;
    [SerializeField]
    public GameObject GameOverText;
    [SerializeField]
    private GameObject Advise;
    [SerializeField]
    private ScoreController ScoreController;

    private void Start()
    {
        GameOverChange();
    }

    //method that generates right text for Textobject for winning condition
    //and winner/loser animations
    void GameOverChange()
    {
        Text UIGameOverText = this.GameOverText.GetComponent<Text>();
        Text UIAdvise = this.Advise.GetComponent<Text>();
        if (ScoreController.SceneID == 1) 
        {
            UIGameOverText.text = "You won with score <color=blue>" + ScoreController.scorePlayer1 + "</color>:<color=green>" + ScoreController.scorePlayer2 + "</color>!";
            UIAdvise.text = "But the bot just warmed up..\nOne more? ツ";
            animatorFoxie.Play("Foxie_win_1");
            animatorKira.Play("Kira_lose_1");
            GoldenRacketLeft.SetActive(true);
            GoldenRacketRight.SetActive(false);
            ScoreController.scorePlayer1 = 0;
            ScoreController.scorePlayer2 = 0;
        }
        else if (ScoreController.SceneID == 2)
        {
            UIGameOverText.text = "You lost with score <color=blue>" + ScoreController.scorePlayer1 + "</color>:<color=green>" + ScoreController.scorePlayer2 + "</color>!";
            UIAdvise.text = "You probably did your best!\nOne more to improve your skill? ツ";
            animatorFoxie.Play("Foxie_lose_1");
            animatorKira.Play("Kira_win_1");
            GoldenRacketLeft.SetActive(false);
            GoldenRacketRight.SetActive(true);
            ScoreController.scorePlayer1 = 0;
            ScoreController.scorePlayer2 = 0;
        }
        else if (ScoreController.SceneID == 3)
        {
            UIGameOverText.text = "<color=blue>Player 1</color> wins! Score - <color=blue>" + ScoreController.scorePlayer1 + "</color>:<color=green>" + ScoreController.scorePlayer2 + "</color>";
            UIAdvise.text = "Better luck next time, <color=green>Player 2</color> ツ";
            animatorFoxie.Play("Foxie_win_1");
            animatorKira.Play("Kira_lose_1");
            GoldenRacketLeft.SetActive(true);
            GoldenRacketRight.SetActive(false);
            ScoreController.scorePlayer1 = 0;
            ScoreController.scorePlayer2 = 0;
        }
        else if (ScoreController.SceneID == 4)
        {
            UIGameOverText.text = "<color=green>Player 2</color> wins! Score - <color=blue>" + ScoreController.scorePlayer1 + "</color>:<color=green>" + ScoreController.scorePlayer2 + "</color>";
            UIAdvise.text = "Better luck next time, <color=blue>Player 1</color> ツ";
            animatorFoxie.Play("Foxie_lose_1");
            animatorKira.Play("Kira_win_1");
            GoldenRacketLeft.SetActive(false);
            GoldenRacketRight.SetActive(true);
            ScoreController.scorePlayer1 = 0;
            ScoreController.scorePlayer2 = 0;
        }
    }
}
