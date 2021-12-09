using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public Rigidbody2D rb;

    public float min_x;
    public float max_x;
    public float min_y;
    public float max_y;

    private Vector2 Velocity;
    public float horizontalVelocity;
    public float verticalVelocity;
    private float jumpVelocity;
    public Vector2 jumpDampening;
    public Vector2 movedVelocity;

    public SpriteRenderer player;

    public float horSpeed;
    public float verSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontalVelocity = Input.GetAxisRaw("Horizontal");
        verticalVelocity = Input.GetAxisRaw("Vertical");
        jumpVelocity = Input.GetAxisRaw("Jump");

        rb.velocity = new Vector2(horizontalVelocity * horSpeed, verticalVelocity * verSpeed);
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, min_x, max_x), Mathf.Clamp(rb.position.y, min_y, max_y));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            player.flipX = false;
        }


    }

    private void Hori()
    {
        
    }

    private void Vert()
    {
        
    }

    private void Jump()
    {
        
    }
}
