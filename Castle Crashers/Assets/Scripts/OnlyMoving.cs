using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyMoving : MonoBehaviour
{

    public float horispeed;
    public float verspeed;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * horispeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * verspeed;

        transform.Translate(horizontal, 0, vertical);
    }
}
