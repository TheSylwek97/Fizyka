using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Transform playerTransform;

    public Transform centerOverlabBox; // radius = 0,01f
    private Rigidbody rb;
    public float walkSpeed = 5.0f;
    public float attackDistance = 3.0f;
    public GameObject player;
    bool isPlayerOnWay;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    bool IsGrounded()
    {
        var listCols = Physics.OverlapSphere(centerOverlabBox.position, 0.1f);

        if (listCols.Length > 0) return true;
        else return false;
    }

    void FixedUpdate()
    {

        if (isPlayerOnWay)
        {
            if (player.tag.Equals("Player"))
            {
                Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                float oryginalX = transform.rotation.x;
                float oryginalZ = transform.rotation.z;

                Quaternion finalRotation = Quaternion.Slerp(transform.rotation, targetRotation, 10000.0f * Time.deltaTime);
                finalRotation.x = oryginalX;
                finalRotation.z = oryginalZ;
                transform.rotation = finalRotation;

                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance > attackDistance)
                {
                    transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            var x = Time.deltaTime * 150.0f;
            var z = Time.deltaTime * 3.0f;

            if (!IsGrounded())
            {
                transform.Rotate(0, x, 0);
            }
            transform.Translate(0, 0, z);

        }
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = transform;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayerOnWay = true;
        }
    }


}