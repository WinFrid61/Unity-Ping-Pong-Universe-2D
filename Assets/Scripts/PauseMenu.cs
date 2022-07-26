using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//script which answers for ingame pause menu to call
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject UIPauseMenu;
    public MusicController MusicController;

    //if ESC pressed, call menu either resume game if was called
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    //method to resume game (unpause music, set inactive pause UI elements and change timescale)
    public void Resume()
    {
        if (!MusicController.audioSource.isPlaying && !MusicController.PausedByUser)
        {
            MusicController.audioSource.UnPause();
        }
        UIPauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //method to pauseresume game (pause music, set  active pause UI elements and change timescale)
    public void Pause()
    {
        if (MusicController.audioSource.isPlaying)
        {
            MusicController.audioSource.Pause();
        }
        UIPauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //method for the button to go back to the main menu
    public void Menu()
    {
        UIPauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

}
