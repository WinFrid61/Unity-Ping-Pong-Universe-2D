using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    public GameObject TotalBounce;
    public BallMovement ballMovement;
    public ScoreController ScoreController;
    private int bounce = 0;

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

        float y = (ballPosition.y - Racketposition.y) / racketheight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

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
            StartCoroutine(this.ballMovement.StartBall(true));
        }
        else if (collision.gameObject.name == "Right")
        {
            Debug.Log("Collision with right wall. Score for Player 1");
            this.ScoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }
    }

}
