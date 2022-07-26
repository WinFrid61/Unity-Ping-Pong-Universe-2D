using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBall : MonoBehaviour
{
    public float movementSpeed;
    public BallMovement ballMovement;

    private void Start()
    {
        StartCoroutine(this.StartBall());
    }

    public IEnumerator StartBall()
    {
        yield return new WaitForSeconds(2);
        this.MoveBall(new Vector2(1, 0));
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float speed = this.movementSpeed;
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = direction * speed;
    }

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

        this.ballMovement.IncreaseHitCounter();
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
