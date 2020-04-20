using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text txtTitle;
    public Text txtGameOverDescription;
    public Text txtResult;
    public Image imgWin;
    public Image imgLose;

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        Debug.Log("retry");
    }

    public void GameOver(float levelResult) //0 = lose, 1 = win
    {
        switch (levelResult)
        {
            case 1:
                txtTitle.text = "You won!";
                txtGameOverDescription.text = "You've saved the planet.";
                txtResult.text = "We are lucky to have you to keep us alive";
                imgLose.gameObject.SetActive(false);
                imgWin.gameObject.SetActive(true);
                break;
            default:
                txtTitle.text = "You lose!";
                txtGameOverDescription.text = "Your planet has been destroyed.";
                txtResult.text = "Don't give up... Let's try again!";
                imgLose.gameObject.SetActive(true);
                imgWin.gameObject.SetActive(false);
                break;
        }

    }
}
