using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockedDown : MonoBehaviour
{
    public Rigidbody player;

    [Header("Knockdown Effects")]
    MeshRenderer cubeRenderer;
    Color knockdownColor = Color.white;
    Color originColor;



    //Time before the player's allowed to stand up n have fun again
    [Header("Knockdown Stats")]
    private float stand_Up_Timer = 2f;
    public float blowback;
    public float movementCooldown = 0;
    public float blowbackLength = 500;
    public float blowbackHeight = 500;



    void Start()
    {
        player = GetComponent<Rigidbody>();
        cubeRenderer = GetComponent<MeshRenderer>();
        originColor = cubeRenderer.material.color;
    }

     
    void Update()
    {
         
    }

    

    /*void Knockdown(Collision collision)
    {
        //Functie veranderen input naar een bool check, if playerGotHit == true...
        if (collision.collider.tag == "Ground")
        {

            Debug.Log("You got knocked down bitch");
            cubeRenderer.material.color = knockdownColor;
            player.velocity = Vector2.zero;
            StartCoroutine(StandUpAfterTime());

        }
            
        
        
         
    }*/

    public void Knockback(Collision col)
    {
         
        if (movementCooldown >= 0)
        {
            Debug.Log(player);

            Debug.Log("Knockback activate");
            player.AddForce(blowback, blowbackHeight, 0, ForceMode.Force);
            player.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
            if (col.collider.tag == "Ground")
            {
                StartCoroutine(StandUpAfterTime());
            }

        }


    }
    
    IEnumerator StandUpAfterTime()
    {
        Physics.IgnoreLayerCollision(8, 8, true);
        Debug.Log("This is running");
        cubeRenderer.material.color = knockdownColor;
        yield return new WaitForSeconds(stand_Up_Timer);
        Physics.IgnoreLayerCollision(8, 8, false);
        cubeRenderer.material.color = originColor;
        Debug.Log("Back in action");
    }
}

