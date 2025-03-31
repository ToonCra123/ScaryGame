using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the player movement
    public float jumpForce = 2f;
    public GameObject playerHead;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make Mouse Cursor invisible
        Cursor.visible = false;
        // Lock the Mouse Cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Move when wasd keys are pressed
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        // Rotate when mouse is moved
        if (Input.GetAxis("Mouse X") != 0)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }

        if (Input.GetAxis("Mouse Y") != 0)
        {
            float xRotation = playerHead.transform.localEulerAngles.x - Input.GetAxis("Mouse Y");
            if (xRotation > 180)
            {
                xRotation -= 360;
            }
            xRotation = Mathf.Clamp(xRotation, -90, 90);
            playerHead.transform.localEulerAngles = new Vector3(xRotation, playerHead.transform.localEulerAngles.y, playerHead.transform.localEulerAngles.z);

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

}
