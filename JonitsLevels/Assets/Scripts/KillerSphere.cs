using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class KillerSphere : MonoBehaviour
{

    bool ShouldGo;
    
    void Update()
    {
        var x = transform.position.x;
        var z = transform.position.z;
        var y = transform.position.y;
        if (ShouldGo == true)
        {
            z = transform.position.z + 1f;

            transform.position = new Vector3(x, y, z);
        }
        else
        {
            if (transform.position.z != 0)
            {
                if (transform.position.z > 0)
                {
                   z = transform.position.z - 0.01f;
                }
            }
        }
        transform.position = new Vector3(x, y, z);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ragdoll"))
            ShouldGo = true;
    }
    void OnTriggerExit(Collider other)
    {
        ShouldGo = false;
    }
}

    */