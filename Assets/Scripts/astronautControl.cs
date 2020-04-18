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
    private Quaternion rotation;

    private Transform pivot;


    void Start()
    {

        pivot = pivotTransform.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
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
            pivot.rotation = Quaternion.RotateTowards(transform.rotation, rotation , rotationSpeed * Time.deltaTime);
        }
    }
}
