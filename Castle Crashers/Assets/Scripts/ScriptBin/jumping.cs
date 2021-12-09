using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{

    public Rigidbody2D rb;

    public float jumpSpeed = 10.0f;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping();
        }
    }

    public IEnumerator Jumping()
    {
        rb.gravityScale = 10;
        rb.AddForce(transform.up * jumpSpeed);
        while (rb.gravityScale != 0)
        {
            rb.gravityScale -= 1 * Time.deltaTime;
        }  
        yield return new WaitForSeconds(2);

    }
}
