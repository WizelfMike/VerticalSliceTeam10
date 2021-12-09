using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockedDown : MonoBehaviour
{
    Collider2D hurtbox;
    public Transform hurtboxPoint;
    public Vector2 hurtboxSize;
    private LayerMask pLayer;


    SpriteRenderer CubeRenderer;
    Color knockdownColor = Color.black;
    Color originColor;



    //Time before the player's allowed to stand up n have fun again
    private float stand_Up_Timer = 2f;
     
     
    void Start()
    {
        //hurtbox = Physics2D.OverlapBox(hurtboxPoint.position, hurtboxSize, enemyLayer);
        CubeRenderer = GetComponent<SpriteRenderer>();
        originColor = CubeRenderer.material.color;
    }

     
    void Update()
    {
        Knockdown();
    }

    public void Knockdown()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Collider2D>().enabled = false;
            Debug.Log("You got knocked down bitch");
            CubeRenderer.material.color = knockdownColor;
            WakeUp();
        }
         
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(hurtboxPoint.position, hurtboxSize);
    }*/

    void WakeUp()
    {
            StartCoroutine(StandUpAfterTime());
    }

    IEnumerator StandUpAfterTime()
    {
        yield return new WaitForSeconds(stand_Up_Timer);
        GetComponent<Collider2D>().enabled = true;
        CubeRenderer.material.color = originColor;
        Debug.Log("Back in action");
    }
}