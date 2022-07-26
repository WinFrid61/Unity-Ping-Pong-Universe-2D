using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script for the right racket manual movement
public class RacketPlayer2 : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    //added new input in build settings (arrows UP-Down), then calculated velocity of the racket
    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical2");
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertical) * movementSpeed;
    }
}
