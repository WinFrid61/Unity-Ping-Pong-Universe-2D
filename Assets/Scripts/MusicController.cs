using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//script for all the ingame music (not menu)
public class MusicController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    public AudioSource audioSource;
    private object currentclip;
    private string currentclipName;
    private int RandomID;
    [System.NonSerialized]
    public bool PausedByUser = false;
    private string minutes;
    private string seconds;
    [SerializeField]
    private GameObject SongName;

    //getting volume value from Player Prefs
    void Start()
    {
        if (PlayerPrefs.HasKey("volumeMusic"))
        {
            audioSource.volume = PlayerPrefs.GetFloat("volumeMusic");
        }
        audioSource.loop = false;
        //object MainMenuMusic = Object.Destroy(MainMenuMusicController);
;    }

    //random pick of the music from array
    public AudioClip GetRandomClip()
    {
        RandomID = Random.Range(0, clips.Length);
        currentclip = clips[RandomID];
        currentclipName = clips[RandomID].name;
        return (AudioClip)currentclip;
    }

    //method to calculate and output length of the audio clip
    void SetClipTime()
    {
        minutes = Mathf.Floor((int)audioSource.clip.length / 60).ToString("00");
        seconds = ((int)audioSource.clip.length % 60).ToString("00");
    }

    void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volumeMusic");
        if (!audioSource.isPlaying && !PausedByUser && !PauseMenu.isPaused)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
            SetClipTime();
        }

        //checking for pause option
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
