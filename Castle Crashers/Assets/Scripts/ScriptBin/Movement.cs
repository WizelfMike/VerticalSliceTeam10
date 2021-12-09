using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform position;

    //public GameObject sprite;
    public SpriteRenderer player;
    public Transform location;

    public float min_x;
    public float max_x;
    public float min_y;
    public float max_y;
    public float maxjump_y;

    float horizontal;
    float vertical;

    public float horSpeed = 10.0f;
    public float verSpeed = 6f;
    public float jumpSpeed = 10.0f;

    private float axisY;

    [SerializeField]private bool isJumping;
    private bool hasLanded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            player.flipX = true;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            player.flipX = false;
        }

        if (transform.position.y <= axisY)
        {
            OnLanding();
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            axisY = transform.position.y;
            isJumping = true;
            rb.gravityScale = 1.5f;
            rb.WakeUp();
            rb.AddForce(new Vector2(transform.position.x + 7.5f, jumpSpeed));
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        while (isJumping)
        {
            print("Kanker");
            return;
        }

        
    }

    private void OnLanding()
    {
        isJumping = false;
        rb.gravityScale = 0f;
        rb.Sleep();
        axisY = transform.position.y;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * horSpeed, vertical * verSpeed);

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, min_x, max_x), Mathf.Clamp(rb.position.y, min_y, max_y));
    }
}