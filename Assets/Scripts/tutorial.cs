using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{

    public string[] tutorialTitles;
    public string[] tutorialDescriptions;
    public Sprite[] tutorialImages;
    public Text actualTitle;
    public Text actualDescription;
    public Image actualImage;

    private int actualStep = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualTitle.text = tutorialTitles[actualStep];
        actualDescription.text = tutorialDescriptions[actualStep];
        actualImage.sprite = tutorialImages[actualStep];
    }

    public void NextStepTutorial()
    {
        actualStep += 1;

        if(actualStep >= tutorialTitles.Length)
        {
            closeTutorial();
        }
    }

    public void closeTutorial()
    {
        Time.timeScale = 1f;
        gameManager._inst.activeChar = gameManager.State.astronaut;
        Destroy(gameObject);
    }
}
