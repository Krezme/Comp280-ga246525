using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementSinglePlayer : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 10f;

    public float gravity = -10f;

    public float jumpHeight = 5f;

    public bool jumpEnabled;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask goundLayer;
    bool isGrounded;

    Vector3 velocity;

    void Update () {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, goundLayer);

        if (isGrounded && velocity.y < 0f) {
            velocity.y = -5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded && jumpEnabled) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
