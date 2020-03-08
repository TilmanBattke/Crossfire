using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonListener : MonoBehaviour
{
    GSM gSM;

    public void Awake()
    {
        gSM = GameObject.FindObjectOfType<GSM>();
    }

    public void Continue()
    {
        gSM.unpauseGame();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Pause()
    {
        gSM.pauseGame();
    }
    
}
