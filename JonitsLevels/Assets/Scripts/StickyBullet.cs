
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBullet : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        var wallRb = collision.transform.GetComponent<Rigidbody>();
        if (wallRb == null || collision.gameObject.layer == LayerMask.NameToLayer("Ragdoll") || !collision.gameObject.CompareTag("TragetToShoot"))
            return;

        var joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = wallRb;
        joint.breakForce = 700;
    }
}
