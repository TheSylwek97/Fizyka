using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour {

   
    [SerializeField]Transform groundCheck;
    [SerializeField]LayerMask groundMask;

    float rayDistance;
    Vector3 rayDirection;

    void FixedUpdate()
    {
        var x = Time.deltaTime * 150.0f;
        var z = Time.deltaTime * 3.0f;

        rayDirection = groundCheck.position - transform.position;
        rayDistance = rayDirection.magnitude;

        //RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDirection, rayDistance, groundMask))
        {
            Debug.DrawRay(transform.position, rayDirection * rayDistance, Color.yellow);
            Debug.Log("Did Hit");
           transform.Translate(0, 0, z);
        }
        else
        {
            Debug.DrawRay(transform.position, rayDirection * 1000, Color.white);
            Debug.Log("Did not Hit");
           transform.Rotate(0, x, 0);
        }
    }

}
