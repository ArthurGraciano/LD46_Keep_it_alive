using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planet : MonoBehaviour
{

    Rigidbody2D rb;
    public static float healthAmount;
    public static int levelEnded;

    public Transform meteor;
    public GameObject hitParticles;
    public GameObject deathEffect;
    public GameObject planetDead;
    public GameObject cannons;
    public GameObject[] planetImprovements;
    private GameObject hitParticlesClone;
    private int improvementNumber = 0;
    private int endGameValue = 0;

    public GameObject losescreen;

    private bool deathEffectPlay;

    //timer
    [SerializeField]
    private Text lvlDurationTxt;
    private float lvlDurationTime;

    // Start is called before the first frame update
    void Start()
    {
        lvlDurationTime = Time.time;
        deathEffectPlay = true;
        healthAmount = 50;
        levelEnded = 0;

        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(timeCounter());
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            

            ExplodePlanet();
            endGameValue = 0;
            levelEnded = 1;
            StartCoroutine(popupDelay(new WaitForSeconds(2.5f)));
        }
        else if (healthAmount >= 100)
        {
            StartCoroutine(popupDelay(new WaitForSeconds(2.5f)));
            endGameValue = 1;
            levelEnded = 1;

        }

        switch (improvementNumber)
        {
            case 0:
                Health(gameObject.GetComponent<SpriteRenderer>());
                break;
            default:
                Health(planetImprovements[improvementNumber - 1].GetComponent<SpriteRenderer>());
                break;
        }
        ImprovePlanet();

        IEnumerator popupDelay(WaitForSeconds waitFor)
        {

            ExplodePlanet();

            yield return waitFor;
            losescreen.SetActive(true);
            losescreen.gameObject.GetComponent<EndGame>().GameOver(endGameValue);
            StopCoroutine("popupDelay");
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("meteor"))
        {
            healthAmount -= 5f;
            hitParticlesClone = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(hitParticlesClone, 2.0f);
            Destroy(collision.gameObject);
        }
        else if (collision.tag.Equals("Item"))
        {

            Destroy(collision.gameObject);
        }

    }

    private void Health(SpriteRenderer planetSprite)
    {
        planetSprite.color = new Color(1f, 1f, 1f, healthAmount / 100f);

        //Debug.Log("color.a: " + planetSprite.color.a);
    }

    private void ImprovePlanet()
    {
        if(healthAmount > 50)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            improvementNumber = 1;

            if (healthAmount > 60)
            {
                improvementNumber = 2;
                if (healthAmount > 70)
                {
                    improvementNumber = 3;
                    if (healthAmount > 80)
                    {
                        improvementNumber = 4;
                    }
                }
            }
            if (improvementNumber < planetImprovements.Length)
            {
                planetImprovements[improvementNumber].SetActive(false);
            }
            planetImprovements[improvementNumber - 1].SetActive(true);
        }
        else
        {
            improvementNumber = 0;
            planetImprovements[improvementNumber].SetActive(false);
        }
    }

    private void ExplodePlanet()
    {
        if (deathEffectPlay == true)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            deathEffectPlay = false;
        }

        SpriteRenderer.Destroy(planetDead);
        //Destroy(gameObject);
        Destroy(planetDead);
        Destroy(cannons);

    }

    IEnumerator timeCounter()
    {
        
        while (levelEnded == 0) 
        {
            float t = Time.time - lvlDurationTime;
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            lvlDurationTxt.text = minutes + "m " + seconds +"s";
        yield return new WaitForSeconds(1f);
        }
        
    }

 }
    