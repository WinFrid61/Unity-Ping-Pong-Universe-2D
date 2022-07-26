using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCollisionController : MonoBehaviour
{
    public MainMenuBallMovement ballMovement;

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

        float y = (ballPosition.y - Racketposition.y) / racketheight;
        this.ballMovement.MoveBall(new Vector2(x, y));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            this.BounceFromRacket(collision);
        }
    }

}
