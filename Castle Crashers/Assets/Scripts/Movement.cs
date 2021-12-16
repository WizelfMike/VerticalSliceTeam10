using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horispeed;
    public float verspeed;

    public int jumpHeight;

    private bool onGround;

    public Transform t_player;
    public Transform t_shadow;

    public SpriteRenderer player;
    public Rigidbody rb;
    public Animator anim;
    public bool m_IsWalking;
    public bool m_IsJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_IsWalking = false;
        Physics.IgnoreCollision(t_player.GetComponent<Collider>(), t_shadow.GetComponent<Collider>());
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * horispeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * verspeed;

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            onGround = false;
            m_IsWalking = false;
            m_IsJumping = true;
        }

        if (onGround)
        {
            m_IsJumping = false;
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            m_IsWalking = true;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            m_IsWalking = true;
        }
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            m_IsWalking = false;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            player.flipX = true;
            m_IsWalking = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            player.flipX = false;
            m_IsWalking = true;
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            m_IsWalking = false;
        }

        if (m_IsWalking == true)
        {
            anim.SetBool("IsWalking", true);
        }
        if (m_IsWalking == false)
        {
            anim.SetBool("IsWalking", false);
        }

        if(m_IsJumping == true)
        {
            anim.SetBool("IsJumping", true);
        }
        if (m_IsJumping == false)
        {
            anim.SetBool("IsJumping", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            onGround = true;
            m_IsJumping = false;
        }
    }
}