using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for the left racket manual movement
public class RacketPlayer1 : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    //added new input in build settings (W-S), then calculated velocity of the racket
    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical1");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertical) * movementSpeed;
    }
}
