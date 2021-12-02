using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    private Vector2 Velocity;
    private Vector2 jumpVelocity;
    public Vector2 jumpDampening;
    public Vector2 movedVelocity;

    public SpriteRenderer player;

    public float speed;

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Hori();
            player.flipX = true;
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            Hori();
            player.flipX = false;
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            Vert();
        }
    }

    private void Hori()
    {
        Velocity = new Vector2(1.0f * speed * Time.deltaTime, 0.0f);
    }

    private void Vert()
    {
        Velocity = new Vector2(0.0f, 1.0f * speed * Time.deltaTime);
    }

    private void Jump()
    {
        jumpVelocity = new Vector2(Velocity.x, Velocity.y);
        jumpVelocity -= jumpDampening;
        Velocity = jumpVelocity + movedVelocity;
    }
}
