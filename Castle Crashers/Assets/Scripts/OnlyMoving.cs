using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnlyMoving : MonoBehaviour
{

    public float horispeed;
    public float verspeed;

    //private float _moveSpeed = 10f;
    //private Vector3 _moveVec = Vector3.zero;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * horispeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * verspeed;

        transform.Translate(horizontal, 0, vertical);

        //transform.Translate(_moveVec * _moveSpeed * Time.deltaTime);
    }

    void MoveUp()
    {
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * verspeed;

        transform.Translate(0, 0, vertical);
    }

    public void OnMovement(InputValue input)
    {
        

        //Vector2 inputVec = input.Get<Vector2>();

        //_moveVec = new Vector3(inputVec.x, inputVec.y, 0);
    }
}
