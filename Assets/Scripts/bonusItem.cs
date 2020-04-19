using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusItem : MonoBehaviour
{   
    [SerializeField]
    private Vector2[] directions;
    private Collider2D itemCollider;
    private Rigidbody2D rb;
    private Transform player;
    [SerializeField]
    [Range(0, 1)]
    private float speed;
    private int randomSpawnRange;
    [SerializeField]
    private Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {   
        
        itemCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = RespawnPointsList.respawnMethod();
        randomSpawnRange = Random.Range(0, 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        _direction = (directions[randomSpawnRange] - rb.position).normalized;
        rb.MovePosition(rb.position + _direction * speed * Time.fixedDeltaTime);
        if(rb.position == directions[randomSpawnRange])
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Astronaut"))
        {
            planet.healthAmount += 5;
            Destroy(gameObject);
        }
    }


}
