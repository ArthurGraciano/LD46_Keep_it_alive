using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePopupManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gameWin;
    public GameObject planet;
    public static float healthAmount;
    void Update()
    {



        if (healthAmount <= 0)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }

        else if (healthAmount >= 100)
        {
            Time.timeScale = 0f;
            gameWin.SetActive(true);
        }

    }
    }
