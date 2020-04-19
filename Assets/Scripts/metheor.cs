using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metheor : enemy
{
public float stopDistance;

//private float attackTime;

 //   public float attackSpeed;

    private void Update()
    {

        if (player != null)
        {

            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
          //  else
          //  {

           //     if (Time.time >= attackTime)
           //     {
          //          attackTime = Time.time + timeBetweenAttacks;
          //      }
        //
           // }

        }

    }
}

