using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astronautControl : MonoBehaviour
{

    public Transform pivotTransform;
    [SerializeField]
    private SpriteRenderer astronaut;
    [SerializeField]
    private GameObject deadAstronaut;

    private float radius;
    [SerializeField]
    [Range(50, 250)]
    private float rotationSpeed;
    private bool canShoot;
    private Quaternion rotation;

    public Transform pivotArma;
    private Transform pivot;

    private Animator anim;
    public GameObject astronautPull;

    private WaitForSeconds waitFor;
    private bool isActive;

    void Start()
    {
        isActive = false;
        canShoot = true;
        pivot = pivotTransform.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;

        anim = GetComponent<Animator>();

        waitFor = new WaitForSeconds(0.8f);

        StartCoroutine(astronautFlipper());
    }

    void Update()
    {
        if (gameManager._inst.activeChar == gameManager.State.astronaut && planet.levelEnded == 0)
        {
            StartCoroutine(astronautFlipper());

            Vector3 orbVector = Camera.main.WorldToScreenPoint(pivotTransform.position);
            orbVector = (Input.mousePosition - orbVector);
            float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

            pivot.position = pivotTransform.position;
            rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            pivot.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        }

        if(planet.levelEnded == 1) 
        {   

            astronautDie();

        }

    }
    private void FixedUpdate()
    {

        if (gameManager._inst.activeChar == gameManager.State.astronaut && Input.GetKey(KeyCode.Mouse0))
        {
            if(canShoot == true && planet.levelEnded != 1)    
            {
                StartCoroutine(astronautCanShoot());
            }
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }

    IEnumerator astronautCanShoot()
    {
        anim.SetBool("isShooting", true);
        shootControl._shootControl.AstronautShoot(pivotArma);
        Instantiate(astronautPull, pivotArma, false);
        canShoot = false;
        yield return waitFor;
        canShoot = true;

    }

    IEnumerator astronautFlipper()
    {
        Vector3 rot = pivot.rotation.eulerAngles;
        yield return new WaitForSeconds(0.2f);
        Vector3 rotT = pivot.rotation.eulerAngles;
        if (rot.z > rotT.z && rot.z - rotT.z < 300)
        {
            astronaut.flipX = true;
            
        }
        else if (rot.z < rotT.z && rot.z - rotT.z > -300)
        {
            astronaut.flipX = false;
            


        }
    }

    public void astronautDie()
    {   
        if(isActive == false) 
        { 
        GameObject deadAstronautClone = Instantiate(deadAstronaut, astronaut.transform.position, Quaternion.identity);
        deadAstronautClone.AddComponent<Rigidbody2D>();
        Rigidbody2D rb = deadAstronautClone.GetComponent<Rigidbody2D>();
         rb.gravityScale = 0;
        rb.AddForce(Vector2.up, ForceMode2D.Impulse);
         rb.AddTorque(30f,ForceMode2D.Force);
        astronaut.enabled = false;
        isActive = true;

        }
    }

}
