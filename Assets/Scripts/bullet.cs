using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject particles;
    private GameObject destroyPs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("meteor") || collision.tag.Equals("Item"))
        {
            Destroy(collision.gameObject);
            destroyPs = Instantiate(particles, transform.position, Quaternion.identity) as GameObject;
            Destroy(destroyPs, 2.0f);
            Destroy(gameObject);
        }

    }
}
