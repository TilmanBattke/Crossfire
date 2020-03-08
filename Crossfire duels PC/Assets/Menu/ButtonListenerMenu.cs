using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonListenerMenu : MonoBehaviour
{

    public Canvas BeginningScreen;
    public Canvas mainMenu;
    public Canvas HelpPanel;

    //self comenting code(yeah)
    private void Start()
    {
        DisplayStartMenu();
    }

    public void LoadMainS()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void setPlayer1char(string input)
    {
        GameInfo.Player1char = input;
    }

    public void setPlayer2char(string input)
    {
        GameInfo.Player2char = input;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void DisplayStartMenu()
    {
        BeginningScreen.enabled = true;
        mainMenu.enabled = false;
        HelpPanel.enabled = false;
    }

    public void DisplayMainMenu()
    {
        BeginningScreen.enabled = false;
        mainMenu.enabled = true;
        HelpPanel.enabled = true;
    }

    public void showHelp()
    {
        HelpPanel.enabled = true;
    }

    public void HideHelp()
    {
        HelpPanel.enabled = false;
    }
}
