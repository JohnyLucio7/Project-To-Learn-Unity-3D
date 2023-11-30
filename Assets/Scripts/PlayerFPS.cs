using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPS : MonoBehaviour
{
    private Gravity gravity;
    [SerializeField] private Vector3 velocity;
    private CharacterController characterController;

    private float speed;
    public float baseSpeed;
    public float RunSpeed;


    public float jumpForce = 4.4f;

    void Start()
    {
        speed = baseSpeed;
        gravity = GetComponent<Gravity>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (gravity.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        if (Input.GetButtonDown("Fire3"))
        {
            speed = RunSpeed;
        }

        if (Input.GetButtonUp("Fire3"))
        {
            speed = baseSpeed;
        }


        Vector3 move = (transform.right * x + transform.forward * z);

        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && gravity.IsGrounded())
        {
            velocity.y = jumpForce;
        }

        velocity.y += gravity.gravity * gravity.gravityScale * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}
