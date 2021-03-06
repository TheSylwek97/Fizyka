﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {


    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float force;
    [SerializeField] Transform target;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoots();
    }

    void Shoots()
    {

        var bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
       bulletInstance.transform.LookAt(target);

        var bulletRigidBody = bulletInstance.GetComponent<Rigidbody>();
        bulletRigidBody.AddForce(bulletInstance.transform.forward * force);
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponentInParent<SimpleCarController>() != null)
            target = other.transform;
    }*/
}
