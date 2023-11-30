using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float gravity;
    public bool isGrounded;

    public float gravityScale = 1;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private void Start()
    {
        gravity = Physics.gravity.y;
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, whatIsGround);
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
