using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{

    Rigidbody2D rb;
    public static float healthAmount;

    public Transform meteor;
    public GameObject hitParticles;
    public GameObject deathEffect;
    public GameObject planetDead;
    public GameObject cannons;
    private GameObject hitParticlesClone;

    public GameObject losescreen;

    private bool deathEffectPlay;

    // Start is called before the first frame update
    void Start()
    {
        deathEffectPlay = true;
        healthAmount = 50;

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {

            StartCoroutine(popupDelay(new WaitForSeconds(5f)));
        }

        Health();

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

    private void Health()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, healthAmount / 100f);

        //Debug.Log("color.a: " + GetComponent<SpriteRenderer>().color.a);
    }

    private void explodePlanet()
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

    IEnumerator popupDelay(WaitForSeconds waitFor)
    {

        explodePlanet();

        yield return waitFor;
        losescreen.SetActive(true);
        StopCoroutine("popupDelay");
    }

}
