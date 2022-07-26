using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMusicController : MonoBehaviour
{
    public MusicController MusicController;
    public GameObject MusicPlayer;
    public GameObject BackGround;
    public GameObject Trash;
    void Awake()
    {
        DontDestroyOnLoad(MusicPlayer);
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(BackGround);
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(Trash);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game_1Player" || scene.name == "Game_2Players")
        {
            MusicController.audioSource.Stop();
            Destroy();
            Destroy();
            Destroy();
        }
        else
        {
            MusicController.audioSource.UnPause();
        }
    }

    void Destroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
