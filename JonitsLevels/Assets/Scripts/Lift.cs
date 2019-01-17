using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    bool ShouldGoUp;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var z = transform.position.z;
        var y = transform.position.y;
        if (ShouldGoUp == true)
        {
            y = transform.position.y + 0.01f;

            transform.position = new Vector3(x, y, z);
        }
        else
        {
            if (transform.position.y != 0)
            {
                if (transform.position.y > 0)
                {
                    y = transform.position.y - 0.01f;
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
        if(other.gameObject.layer == LayerMask.NameToLayer("Ragdoll"))
            ShouldGoUp = true;

    }
    void OnTriggerExit(Collider other)
    {
        ShouldGoUp = false;
    }
}
