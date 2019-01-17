using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class L2MoveNPC : MonoBehaviour {

    private Transform playerTransform;

    public Transform centerOverlabBox; // radius = 0,01f
    public Transform centerOverlabBoxForPlayer; // radius = 5f
    private  Rigidbody rb;
    private Rigidbody rbPlayer;

    public bool attackPlayer;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

      bool isPlayerNotOnWay()
    {
        var listColsPl = Physics.OverlapSphere(centerOverlabBox.position, 5f);

        if (listColsPl.Length > 0) return true;
        else return false;
    }
	  bool IsGrounded()
    {
        var listCols = Physics.OverlapSphere(centerOverlabBox.position, 0.01f);

        if (listCols.Length > 0) return true;
        else return false;
    }

	// Update is called once per frame
	void FixedUpdate () {

        var x =  Time.deltaTime * 150.0f;
        var z =  Time.deltaTime * 3.0f;

        if (!IsGrounded())
        {
             transform.Rotate(0, x, 0);

        }

         transform.Translate(0, 0, z);
        
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = transform;
    }

  
}
*/