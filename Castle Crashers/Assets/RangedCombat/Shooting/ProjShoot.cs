using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjShoot : MonoBehaviour
{
    public float launchForce;

    public GameObject projectile;

    public Transform firePoint;

    public bool projOnScreen;
     
    void Start()
    {
        projOnScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {   
        if(!projOnScreen)
        {
            GameObject projIns = Instantiate(projectile, firePoint.position, transform.rotation);

            projIns.GetComponent<Rigidbody>().AddForce(transform.right * launchForce);
        }

        projOnScreen = true;
    }
}

