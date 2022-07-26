using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float SpeedPerHit;
    [SerializeField]
    private float MaxSpeed;
    private int hitCounter = 0;

    private void Start()
    {
        StartCoroutine(this.StartBall());
    }

    //method to set start position of the ball
    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if(isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-240, -407, 7.27f);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(69, -407, 7.27f);
        }
    }

    //coroutine which calls methods to position ball based on the starting player,
    //then adding some force to the player's racket after 2 seconds delay
    public IEnumerator StartBall (bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
        {
            this.MoveBall(new Vector2(-1, 0));
        }
        else
        {
            this.MoveBall(new Vector2(1, 0));
        }
    }

    //method which answers for ball movement
    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float speed = this.movementSpeed + this.SpeedPerHit * this.hitCounter;
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = direction * speed;
    }

    //method which increased hit counter based on the difference between increased (per hit) speed and MAX speed
    public void IncreaseHitCounter()
    {
        if (this.hitCounter * this.SpeedPerHit <= this.MaxSpeed)
        {
            this.hitCounter++;
        }
    }
    
}
