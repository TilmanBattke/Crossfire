using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIM : MonoBehaviour
{
    public Canvas hUD;
    public Canvas pauseM;
    public Canvas EndG;
    public Image Winner;
    public Sprite Player1Win;
    public Sprite Player2Win;

    void Start()
    {
        hUD.enabled = true;
        pauseM.enabled = false;
        EndG.enabled = false;
    }

    public void disableHUD()
    {
        hUD.enabled = false;
    }

    public void enableHUD()
    {
        hUD.enabled = true;
        pauseM.enabled = false;
        EndG.enabled = false;
    }

    public void enablePauseM()
    {
        disableHUD();
        pauseM.enabled = true;
        EndG.enabled = false;
    }

    public void enableEndM(string a)
    {
        disableHUD();
        if (a.Equals("Player1"))
        {
            Winner.sprite = Player1Win;
        }
        else
        {
            Winner.sprite = Player2Win;
        }
        EndG.enabled = true;
        EndG.GetComponentInChildren<KOS>().enabled = true;
        pauseM.enabled = false;

    }
    
}
