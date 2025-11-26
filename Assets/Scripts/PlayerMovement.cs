using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody niko;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    bool doubleJump;

    void Start()
    {
        niko = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        niko.linearVelocity = new Vector3(horizontalInput * movementSpeed, niko.linearVelocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            niko.linearVelocity = new Vector3(niko.linearVelocity.x, jumpForce, niko.linearVelocity.z);
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump") && !IsGrounded() && doubleJump)
        {
            niko.linearVelocity = new Vector3(niko.linearVelocity.x, jumpForce, niko.linearVelocity.z);
            doubleJump = false;
        }



    }


    void Jump()
    {
        Jump();
    }






    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
        }

    }


    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }







        















    


}










































































    




















