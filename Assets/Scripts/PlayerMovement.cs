using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody niko;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;


    void Start()
    {
        niko = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        niko.linearVelocity = new Vector3(horizontalInput * 5f, niko.linearVelocity.y, verticalInput * 5f);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            niko.linearVelocity = new Vector3(niko.linearVelocity.x, jumpForce, niko.linearVelocity.z);
        }






    }


    bool IsGrounded()
    {
       return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}










































































    




















