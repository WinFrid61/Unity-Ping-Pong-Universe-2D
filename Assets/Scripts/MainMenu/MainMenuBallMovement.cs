using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBallMovement : MonoBehaviour
{
    public float movementSpeed;

    private void Start()
    {
        StartCoroutine(this.StartBall());
    }

    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(129, -480, 8.79f);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(129, -480, 8.79f);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);
        yield return new WaitForSeconds(1);
        if (isStartingPlayer1)
        {
            this.MoveBall(new Vector2(-1, 0));
        }
        else
        {
            this.MoveBall(new Vector2(1, 0));
        }
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = direction * this.movementSpeed;
    }

}
