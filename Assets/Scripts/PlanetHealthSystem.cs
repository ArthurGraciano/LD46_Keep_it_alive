using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetHealthSystem : MonoBehaviour
{
    public SpriteRenderer PlanetAlive;
    private Slider slider;
    private float AlphaValue;
    private float FillAmount;

    void Update()
    {
        PlanetAlive = GetComponent<SpriteRenderer>();
        PlanetAlive.color = Color.(255f,255f,255f,planet.healthAmount / 100);
        
        slider.value = planet.healthAmount;
        //localscale.x = planet.healthAmount;
        //transform.localScale = localscale;
    }
}
