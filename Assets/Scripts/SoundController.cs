using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource WallSound;
    public AudioSource RacketSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            this.RacketSound.Play();
        }
        else
        {
            this.WallSound.Play();
        }
    }
}
