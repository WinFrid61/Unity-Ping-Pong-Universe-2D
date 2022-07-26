using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private GameObject MainMenuChoosePlayerPanel;

    public void MainMenuScene1()
    {
        MainMenuPanel.SetActive(true);
        MainMenuChoosePlayerPanel.SetActive(false);
    }
    public void MainMenuScene2()
    {
        MainMenuPanel.SetActive(false);
        MainMenuChoosePlayerPanel.SetActive(true);
    }

}
