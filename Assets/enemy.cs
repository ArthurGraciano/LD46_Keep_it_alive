using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //  public int health;
    [HideInInspector]
    public Transform player;
    public float stopDistance;

    public GameObject hitPlanet;



    public float speed;
    //public float timeBetweenAttacks;
    //  public int damage;

    //   public int pickupChance;
    //  public GameObject[] pickups;

    //   public int healthPickupChance;
    //  public GameObject healthPickup;

    //public GameObject deathEffect;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {

            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

                // Destroy(gameObject);


            }

            else
            {
                Instantiate(hitPlanet, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
       
     
    

      