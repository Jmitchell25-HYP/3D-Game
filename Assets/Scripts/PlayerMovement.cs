using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody niko;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] float mouseSentivity = 100f;
    float xRotation = 0f;
    [SerializeField] Transform playerCamera; // Assign your camera in the Inspector


    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    bool doubleJump;

    void Start()
    {
        niko = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the Cursor in place

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

        //Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSentivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSentivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotate camera up/down
        transform.Rotate(Vector3.up * mouseX); // Rotate player left/right

        // Move in the direction the player is facing
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        niko.linearVelocity = new Vector3(moveDirection.x * movementSpeed, niko.linearVelocity.y, moveDirection.z * movementSpeed);


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










































































    




















