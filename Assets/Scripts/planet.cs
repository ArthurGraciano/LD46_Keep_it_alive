using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{

    Rigidbody2D rb;
    public static float healthAmount;

    public Transform meteor;

    public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 1;
        rb = GetComponent<Rigidbody2D>();
        meteor = GameObject.FindGameObjectWithTag("meteor").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("meteor"))
        {
            healthAmount -= 0.1f;
        }

    }
}
