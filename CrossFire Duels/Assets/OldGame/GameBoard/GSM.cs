using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSM : MonoBehaviour
{
    public UIM uim;
    public bool gamePaused;
    public bool gameOver;
    public GameObject spawn1;
    public GameObject spawn2;

    public GameObject BlueMage;
    public GameObject FireMage;
    public GameObject Mage3;

    void Start()
    {
        if (GameInfo.Player1char.Equals("Mage3"))
        {
            GameObject p1 = Instantiate(Mage3, spawn1.transform.position, spawn1.transform.rotation);
            p1.SetActive(true);
            p1.tag = "Player1";
            p1.layer = 11;
        }
        else if (GameInfo.Player1char.Equals("FireMage"))
        {
            GameObject p1 = Instantiate(FireMage, spawn1.transform.position, spawn1.transform.rotation);
            p1.SetActive(true);
            p1.tag = "Player1";
            p1.layer = 11;
        }
        else
        {
            GameObject p1 = Instantiate(BlueMage, spawn1.transform.position, spawn1.transform.rotation);
            p1.SetActive(true);
            p1.tag = "Player1";
            p1.layer = 11;
        }
        if (GameInfo.Player2char.Equals("Mage3"))
        {
            GameObject p2 = Instantiate(Mage3, spawn2.transform.position, spawn2.transform.rotation);
            p2.SetActive(true);
            p2.tag = "Player2";
            p2.layer = 12;
        }
        else if (GameInfo.Player2char.Equals("FireMage"))
        {
            GameObject p2 = Instantiate(FireMage, spawn2.transform.position, spawn2.transform.rotation);
            p2.SetActive(true);
            p2.tag = "Player2";
            p2.layer = 12;
        }
        else
        {
            GameObject p2 = Instantiate(BlueMage, spawn2.transform.position, spawn2.transform.rotation);
            p2.SetActive(true);
            p2.tag = "Player2";
            p2.layer = 12;
        }


        Time.timeScale = 1;
        gamePaused = false;
        gameOver = false;
        uim.enableHUD();
    }
    
    public void pauseGame()
    {
        gamePaused = true;
        uim.enablePauseM();
        Time.timeScale = 0;
    }

    public void unpauseGame()
    {
        gamePaused = false;
        uim.enableHUD();
        Time.timeScale = 1;
    }

    public void GameEnd(string a)
    {
        gameOver = true;
        uim.enableEndM(a);
        Time.timeScale = 0;
        
    }
}
