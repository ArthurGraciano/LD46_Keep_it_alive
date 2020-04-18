using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonControl : MonoBehaviour
{
    
    public Transform cannonPivot;
    private Transform pivot;
    private bool automaticShoot;
    
    [SerializeField]
    [Range(50, 250)]
    private float rotationSpeed;
    private float radius;

    private Quaternion rotation;

    [SerializeField]
    [Range(0, 3)]
    private float waitTimeToShoot;
    private float shootTimer;
    

    public Transform[] PivotTransform;

    private WaitForSeconds waitFor;


    void Start()
    {
        automaticShoot = false;
        waitFor = new WaitForSeconds(waitTimeToShoot);
        pivot = cannonPivot.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }

    void Update()
    {
        if (gameManager._inst.activeChar == gameManager.State.cannons)
        {
            automaticShoot = false;
            Vector3 orbVector = Camera.main.WorldToScreenPoint(cannonPivot.position);
            orbVector = Input.mousePosition - orbVector;
            float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

            pivot.position = cannonPivot.position;
            rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            pivot.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            shootBehaviour();
        }

       // if (automaticShoot == true)
       // {
        //    StartCoroutine(Shoot());
        //}
    }


    public void shootBehaviour()
    {
        if (Input.GetKey("mouse 0") && shootTimer < Time.time)
        {
            StartCoroutine(Shoot());
        }

       // if (Input.GetKey("mouse 0") && Input.GetKeyUp("mouse 1") )
       // {
       //     gameManager._inst.activeChar = gameManager.State.astronaut;
       //     automaticShoot = true;
       //  }
    }

    IEnumerator Shoot()
    {
        shootTimer = Time.time + waitTimeToShoot;

        foreach (Transform pivots in PivotTransform)
        {
            shootControl._shootControl.CannonShoot(pivots);
        }
        yield return waitFor;
    }
}
