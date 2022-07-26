using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hard to say that it's AI, this script simply moves player 2's racket,
//calculating, if there is a difference between upper pointt of racket (y) and ball (y)
public class SinglePlayerAI : MonoBehaviour
{

    public float movementSpeed;
    public GameObject ball;
    private void FixedUpdate()
    {
        if (Mathf.Abs(this.transform.position.y - ball.transform.position.y) > 50)
        {
            if (transform.position.y < ball.transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); 
        }
    }
}
