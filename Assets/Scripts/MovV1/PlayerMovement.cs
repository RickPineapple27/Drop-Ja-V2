using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;

    public float gravity = -9.81f;
    Vector3 velocity;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float sphereRadius = 0.3F;
    public LayerMask groundMask;

    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,sphereRadius,groundMask);
        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        Vector3 move = transform.right * x +transform.forward * z;
        velocity.y += gravity*Time.deltaTime;

        characterController.Move(move* speed * Time.deltaTime);
        characterController.Move(velocity*Time.deltaTime);

        

    }
}
