using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject UIPauseMenu;
    public MusicController MusicController;

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

    public void Menu()
    {
        UIPauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

}
