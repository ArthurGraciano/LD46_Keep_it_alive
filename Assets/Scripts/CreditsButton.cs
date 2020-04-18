using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{
    public GameObject Panel;

    public void PlayCredits()
    {
        Panel.SetActive(false);
    }
}
