using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script to create DontDestroyOnLoad gameobjects
//they need to continue playing music in other scenes
public class MainMenuMusicController : MonoBehaviour
{
    [SerializeField]
    private ActiveSceneCheck ActiveSceneCheck;

    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<MainMenuMusicController>().Length; i++)
        {
            if (Object.FindObjectsOfType<MainMenuMusicController>()[i] != this)
            {
                if (Object.FindObjectsOfType<MainMenuMusicController>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);                }
            }
        }
            DontDestroyOnLoad(gameObject);
    }
}
