using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float jumpForce = 5f;
    private Transform playerTransform;
    public Transform srodekOverlabBoxa;


    [Range(1f, 100f)] [SerializeField] float movementSpeed = 1f;
    private float walkSpeed = 0.05f;
    private float runSpeed = 0.1f;
    private float sneakSpeed = 0.025f;


    [SerializeField] float rotationSpeed = 1f;
    public float jumpHeight;

    Rigidbody rb;
    Animator anima;
    CapsuleCollider col_size;
    Rigidbody[] rbs;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anima = GetComponent<Animator>();

        rbs = GetComponentsInChildren<Rigidbody>();
        SetRigidbodiesToKinematic(false);
    }

    void SetRigidbodiesToKinematic(bool toggle)
    {
        foreach (Rigidbody r in rbs)
        {
            r.isKinematic = toggle;
            r.detectCollisions = !toggle;
        }
    }

    void Update()
    {
        //skakanie 

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        var x = Input.GetAxis("Vertical") * Time.deltaTime * 150.0f * movementSpeed;
        var z = Input.GetAxis("Horizontal") * 3.0f * rotationSpeed;

        transform.Translate(0, 0, x);
        rb.angularVelocity = new Vector3(0, z, 0);
        //skradanie

        if (Input.GetKey(KeyCode.LeftControl))
        {
            //kontroler skradania
            movementSpeed = sneakSpeed;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anima.SetBool("isWalking", false);
                anima.SetBool("isIdle", false);
                anima.SetBool("isRunning", false);
                anima.SetBool("isSneaking", true);

            }

            else
            {
                anima.SetBool("isWalking", false);
                anima.SetBool("isIdle", true);
                anima.SetBool("isRunning", false);
                anima.SetBool("isSneaking", false);

            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = runSpeed;

            //kontroler biegu
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anima.SetBool("isWalking", false);
                anima.SetBool("isIdle", false);
                anima.SetBool("isRunning", true);
                anima.SetBool("isSneaking", false);
            }

            else
            {
                anima.SetBool("isWalking", false);
                anima.SetBool("isIdle", true);
                anima.SetBool("isRunning", false);
                anima.SetBool("isSneaking", false);

            }
        }

        //chodzenie

        else //if (!isSneaking)
        {
            movementSpeed = walkSpeed;
            //kontroler chodzenia

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                anima.SetBool("isWalking", true);
                anima.SetBool("isRunning", false);
                anima.SetBool("isIdle", false);
                anima.SetBool("isSneaking", false);

            }

            else
            {
                anima.SetBool("isWalking", false);
                anima.SetBool("isRunning", false);
                anima.SetBool("isIdle", true);
                anima.SetBool("isSneaking", false);

            }

        }
    }

    private void Awake()
    {
        playerTransform = transform;
    }


    public void SwitchToRagdoll()
    {

        anima.enabled = false;
        //SetRigidbodiesToKinematic(true);
        Invoke("SwitchToAnimatedCharacter", 5f);
    }

    void SwitchToAnimatedCharacter()
    {
        anima.enabled = true;
        SetRigidbodiesToKinematic(false);
    }

    bool IsGrounded()
    {
        var listaCols = Physics.OverlapSphere(srodekOverlabBoxa.position, 0.01f);

        if (listaCols.Length > 0) return true;
        else return false;
    }

}
