using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float horispeed;
    public float verspeed;

    public int jumpHeight;

    public bool onGround;

    public Transform t_player;
    public Transform t_shadow;

    public SpriteRenderer player;
    public Rigidbody rb;
    public Animator anim;
    public bool m_IsWalking;
    public bool m_IsJumping;
    public PlayerControlls playercontroller;

    Vector2 moveDirection = Vector2.zero;

    //
	void Awake()
	{
		playercontroller = new PlayerControlls();
		playercontroller.Enable();
		/*playercontroller.Player.Movement.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        playercontroller.Player.Movement.canceled += ctx => moveDirection = Vector2.zero;*/

	}


	private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_IsWalking = false;
        Physics.IgnoreCollision(t_player.GetComponent<Collider>(), t_shadow.GetComponent<Collider>());
    }

    private void Update()
    {

        float horizontal = moveDirection.x * Time.deltaTime * horispeed;
        float vertical = moveDirection.y * Time.deltaTime * verspeed;

        transform.Translate(horizontal, 0, vertical);

        if (vertical > 0)
        {
            m_IsWalking = true;
        }
        if (vertical < 0)
        {
            m_IsWalking = true;
        }
        if (vertical == 0)
        {
            m_IsWalking = false;
        }
        if (horizontal > 0)
        {
            t_player.localScale = new Vector3(-0.15f, 0.15f, 0.15f);
            t_shadow.localScale = new Vector3(-6.666666f, 6.666666f, 6.666666f);
            m_IsWalking = true;
        }
        else if (horizontal < 0)
        {
            t_player.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            t_shadow.localScale = new Vector3(6.666666f, 6.666666f, 6.666666f);
            m_IsWalking = true;
        }
        if (horizontal == 0)
        {
            m_IsWalking = false;
        }

        // Setting Animation bools True. Nothing more.
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

    public void Jump()
	{
		if (onGround)
		{
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            onGround = false;
            m_IsWalking = false;
            m_IsJumping = true;
        }
		else
		{
            return;
		}
    }
    public void Moving(InputAction.CallbackContext ctx) => moveDirection = ctx.ReadValue<Vector2>();

	void OnEnable()
	{
		playercontroller.Player.Enable();
	}

	void OnDisable()
	{
		playercontroller.Player.Disable();
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