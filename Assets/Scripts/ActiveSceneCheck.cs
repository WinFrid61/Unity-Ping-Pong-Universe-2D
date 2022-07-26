using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script needs to delete DontDestroyOnLoad objects in scenes which already have other music to play
public class ActiveSceneCheck : MonoBehaviour
{
    [System.NonSerialized]
    public string currentScene;
    private object[] NeedToDestroyObject;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log("ActiveSceneCheck - " + currentScene);

        if (currentScene == "Game_1Player" || currentScene == "Game_2Players")
        {
            Destroy(GameObject.FindGameObjectWithTag("BackGround(M)"));
            Destroy(GameObject.FindGameObjectWithTag("MusicPlayer(M)"));
            Destroy(GameObject.FindGameObjectWithTag("Trash(M)"));
        }
    }
}
