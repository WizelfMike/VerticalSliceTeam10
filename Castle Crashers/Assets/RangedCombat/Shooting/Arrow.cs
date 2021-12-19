using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Arrow : MonoBehaviour
{
    Rigidbody rb;


    
    public GameObject player;

    public GameObject arrow;

    public Transform rotationA;

    public KnockedDown getKnockedDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        getKnockedDown = GameObject.Find("Player2").GetComponent<KnockedDown>(); 
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(arrow);
            getKnockedDown.Knockback(collision);
            
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
    }


    //Moet nog een start up animation aanmaken voordat de pijl wordt afgevuurt
}
