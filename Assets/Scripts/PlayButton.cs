using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

   

    public void PlayGame()
    {
        Debug.Log("retry");
        SceneManager.LoadScene("SampleScene");
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
