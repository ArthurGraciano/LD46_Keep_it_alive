using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{
    public GameObject PanelMainMenu;
    public GameObject PanelCredits;

    public void PlayCredits()
    {
        PanelMainMenu.SetActive(false);
        PanelCredits.SetActive(true);
    }
}
