using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject PanelCredits;

    public void CloseCredits()
    {
        PanelCredits.SetActive(false);
        Panel.SetActive(true);
        
    }
}
