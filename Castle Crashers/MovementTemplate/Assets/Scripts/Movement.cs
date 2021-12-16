using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horispeed;
    public float verspeed;

    private bool onGround;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * horispeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * verspeed;

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            onGround = false;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            onGround = true;
        }
    }
}
