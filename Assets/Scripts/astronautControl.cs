using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astronautControl : MonoBehaviour
{

    public Transform pivotTransform;
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

    void Start()
    {
        canShoot = true;
        pivot = pivotTransform.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;

        anim = GetComponent<Animator>();

        waitFor = new WaitForSeconds(2f);
    }

    void Update()
    {
        if (gameManager._inst.activeChar == gameManager.State.astronaut)
        {
            

            Vector3 orbVector = Camera.main.WorldToScreenPoint(pivotTransform.position);
            orbVector = (Input.mousePosition - orbVector);
            float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

            pivot.position = pivotTransform.position;
            rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            pivot.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        }

    }
    private void FixedUpdate()
    {

        if (gameManager._inst.activeChar == gameManager.State.astronaut && Input.GetKey(KeyCode.Mouse0))
        {
            if(canShoot == true)    
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

}
