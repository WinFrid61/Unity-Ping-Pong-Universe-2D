using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;
    private object currentclip;
    private string currentclipName;
    private int RandomID;
    [System.NonSerialized]
    public bool PausedByUser = false;
    private string minutes;
    private string seconds;
    public GameObject SongName;


    void Start()
    {
        audioSource.loop = false;
    }

    public AudioClip GetRandomClip()
    {
        RandomID = Random.Range(0, clips.Length);
        currentclip = clips[RandomID];
        currentclipName = clips[RandomID].name;
        return (AudioClip)currentclip;
    }

    void SetClipTime()
    {
        minutes = Mathf.Floor((int)audioSource.clip.length / 60).ToString("00");
        seconds = ((int)audioSource.clip.length % 60).ToString("00");
    }

    void Update()
    {
        if (!audioSource.isPlaying && !PausedByUser && !PauseMenu.isPaused)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
            SetClipTime();
        }


        if (Input.GetKeyDown(KeyCode.N))
        {
            if (PausedByUser)
            {
                Debug.Log("Space pressed to Unpause!");
                PausedByUser = false;
                audioSource.UnPause();
            }
            else if (!PausedByUser)
            {
                Debug.Log("Space pressed to Pause!");
                PausedByUser = true;
                audioSource.Pause();
            }

        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            audioSource.clip = GetRandomClip();
        }

        Text UISongName = this.SongName.GetComponent<Text>();
        UISongName.text = "Currently playing: " + currentclipName + ".mp3 - (Length: " + minutes + ":" + seconds + ")";
    }
}
