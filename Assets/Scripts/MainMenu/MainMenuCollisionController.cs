using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCollisionController : MonoBehaviour
{
    [SerializeField]
    private MainMenuBallMovement ballMovement;

    //method which calculates ball direction
    //changes X coordinates for the opposite direction
    void BounceFromRacket(Collision2D collision)
    {
        Vector3 ballPosition = this.transform.position;
        Vector3 Racketposition = collision.gameObject.transform.position;

        float racketheight = collision.collider.bounds.size.y;

        float x = 0f;
        if (collision.gameObject.name == "Player1")
        {
            x = 1f;
        }
        else if (collision.gameObject.name == "Player2")
        {
            x = -1f;
        }

        //Correct ball direction (if ball hits upper side of racket, directions changes to go up and vice versa)
        float y = (ballPosition.y - Racketposition.y) / racketheight;
        //method from the script BallMovement which answers for ball movement
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    //method which helps to bounce the ball from the racket, checking for racket itself
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            this.BounceFromRacket(collision);
        }
    }

}
