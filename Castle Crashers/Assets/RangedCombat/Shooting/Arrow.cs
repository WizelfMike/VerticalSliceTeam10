using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject player;

    public GameObject arrow;

    public Transform rotationA;

    private ProjShoot arrOnScreen;

    private KnockedDown getKnockedDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         
    }

    // Update is called once per frame
    void Update()
    {
        TrackMovement();
        
    }

    void TrackMovement()
    {
        Vector2 direction = rb.velocity;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "pTag")
        {
            //getKnockedDown.Knockdown();
            Destroy(arrow);
        }

        else if(collision.collider.tag == "Ground")
        {
            Debug.Log("Object hit");
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            RemoveArrow();
        }        
        
    }

    void RemoveArrow()
    {
        StartCoroutine(GroundStick());
    }

    IEnumerator GroundStick()
    {
        Debug.Log("Object hit");
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        yield return new WaitForSeconds(0.7f);
        Destroy(arrow);
        //ProjShoot.projOnScreen = false;
    }

}
