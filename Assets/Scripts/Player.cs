using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public Collider collider; 

    public Vector3 jumpForce;

    bool isTouchingGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //take input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTouchingGround)
                rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isTouchingGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isTouchingGround = false;
    }
}
