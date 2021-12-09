using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    public Vector3 jump;
    public Rigidbody rb;

    public SpriteRenderer player;

    float horizontal;
    float vertical;

    public float horSpeed = 10.0f;
    public float verSpeed = 6f;
    public float jumpForce = 2.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 15.0f, 0.0f);
    }

    void Jump(Vector3 direction)
    {
        Vector3 horizontalVector = new Vector3(direction.x, 0, direction.z) * jumpForce * 40;
        rb.AddForce(horizontalVector, ForceMode.Force);
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            player.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            player.flipX = false;
        }

        if (Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector3(horizontal * horSpeed, 0, vertical * verSpeed);
    }

}
