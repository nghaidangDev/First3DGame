using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 veloticy;

    bool isGrounded;


    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && veloticy.y < 0)
        {
            veloticy.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        //right is the red Axis, foward is the blue axis
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Check if the player is on ground so he can jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            veloticy.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        veloticy.y += gravity * Time.deltaTime;

        controller.Move(veloticy * Time.deltaTime);
    }
}
