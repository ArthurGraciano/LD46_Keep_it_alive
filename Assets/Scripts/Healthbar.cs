using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    //Vector3 localscale;
    public Image healthBar;
    private Slider slider;
    
    // Start is called before the first frame update
    void Awake()
    {
        // localscale = transform.localScale;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = planet.healthAmount;
        //localscale.x = planet.healthAmount;
        //transform.localScale = localscale;
    }
}
