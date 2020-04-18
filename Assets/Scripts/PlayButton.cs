using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public GameObject Panel;

    public void PlayGame()
    {
        Panel.SetActive(false);
    }
}
