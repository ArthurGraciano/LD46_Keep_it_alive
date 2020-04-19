using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject particles;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("meteor"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(particles, transform.position, Quaternion.identity);
        }

    }
}
