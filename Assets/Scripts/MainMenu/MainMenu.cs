using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private GameObject MainMenuChoosePlayerPanel;

    //Script to activate 1nd part of main menu where player can choose playtype
    //simply activates and deactivates UI panel when needed
    public void MainMenuScene1()
    {
        MainMenuPanel.SetActive(true);
        MainMenuChoosePlayerPanel.SetActive(false);
    }

    //Script to activate 2nd part of main menu where player can choose playtype
    //simply activates and deactivates UI panel when needed
    public void MainMenuScene2()
    {
        MainMenuPanel.SetActive(false);
        MainMenuChoosePlayerPanel.SetActive(true);
    }

}
