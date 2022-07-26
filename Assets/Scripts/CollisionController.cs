using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    [SerializeField]
    private Animator animatorFoxie;
    [SerializeField]
    private Animator animatorKira;
    [SerializeField]
    private GameObject TotalBounce;
    [SerializeField]
    private BallMovement ballMovement;
    [SerializeField]
    private ScoreController ScoreController;
    private int bounce = 0;

    //method which calculates ball direction
    //changes X coordinates for the opposite direction
    void BounceFromRacket(Collision2D collision)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 Racketposition = collision.gameObject.transform.position;
        Text UITotalBounce = this.TotalBounce.GetComponent<Text>();

        float racketheight = collision.collider.bounds.size.y;

        float x = 0f;
        if (collision.gameObject.name == "Player1")
        {
            bounce++;
            x = 1f;
            UITotalBounce.text = this.bounce.ToString();
        }
        else if (collision.gameObject.name == "Player2")
        {
            bounce++;
            x = -1f;
            UITotalBounce.text = this.bounce.ToString();
        }

        //Correct ball direction (if ball hits upper side of racket, directions changes to go up and vice versa)
        float y = (ballPosition.y - Racketposition.y) / racketheight;

        this.ballMovement.IncreaseHitCounter();
        //method from the script BallMovement which answers for ball movement
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    //method which helps to bounce the ball from the racket, checking for racket itself 
    //and play animations based on player's achievement
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            this.BounceFromRacket(collision);
        }
        else if (collision.gameObject.name == "Left")
        {
            Debug.Log("Collision with left wall. Score for Player 2");
            this.ScoreController.GoalPlayer2();
            animatorFoxie.Play("Foxie_lose");
            animatorKira.Play("Kira_win");
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "Right")
        {
            Debug.Log("Collision with right wall. Score for Player 1");
            animatorFoxie.Play("Foxie_win");
            animatorKira.Play("Kira_lose");
            this.ScoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }

}
