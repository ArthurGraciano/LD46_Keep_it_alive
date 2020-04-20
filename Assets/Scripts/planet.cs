using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planet : MonoBehaviour
{

    Rigidbody2D rb;
    public static float healthAmount;

    public Transform meteor;
    public GameObject hitParticles;
    public GameObject deathEffect;
    public GameObject planetDead;
    public GameObject cannons;
    public GameObject[] planetImprovements;
    private GameObject hitParticlesClone;
    private int improvementNumber = 0;

    public GameObject losescreen;

    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 90;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            ExplodePlanet();
            losescreen.SetActive(true);
            losescreen.gameObject.GetComponent<EndGame>().GameOver(0);
        }
        else if(healthAmount >= 100)
        {
            losescreen.SetActive(true);
            losescreen.gameObject.GetComponent<EndGame>().GameOver(1);
        }

        switch (improvementNumber)
        {
            case 0:
                Health(gameObject.GetComponent<SpriteRenderer>());
                break;
            default:
                Health(planetImprovements[improvementNumber-1].GetComponent<SpriteRenderer>());
                break;
        }
        ImprovePlanet();

    }

    private void OnTriggerEnter2D(Collider2D collision)
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

        //Debug.Log("color.a: " + GetComponent<SpriteRenderer>().color.a);
    }

    private void ImprovePlanet()
    {
        if(healthAmount > 50)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            improvementNumber = 1;
            planetImprovements[improvementNumber-1].SetActive(true);

            if(healthAmount > 60)
            {
                improvementNumber = 2;
                planetImprovements[improvementNumber-1].SetActive(true);

                if (healthAmount > 70)
                {
                    improvementNumber = 3;
                    planetImprovements[improvementNumber-1].SetActive(true);

                    if (healthAmount > 80)
                    {
                        improvementNumber = 4;
                        planetImprovements[improvementNumber-1].SetActive(true);

                        if (healthAmount > 90)
                        {
                            improvementNumber = 5;
                            planetImprovements[improvementNumber - 1].SetActive(true);
                        }
                    }
                }
            }
        }
    }

    private void ExplodePlanet()
    {

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
        Destroy(planetDead);
        Destroy(cannons);

    }

    

 }
