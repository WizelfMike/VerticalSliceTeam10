using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnlyMoving : MonoBehaviour
{

    public float horispeed;
    public float verspeed;
    public PlayerControlls playercontroller;

    Vector2 moveDirection = Vector2.zero;

	//private float _moveSpeed = 10f;
	//private Vector3 _moveVec = Vector3.zero;


	void Awake()
	{
       /* playercontroller = new PlayerControlls();

        playercontroller.Player.Movement.performed += ctx => moveDirection = ctx.ReadValue<Vector2>();
        playercontroller.Player.Movement.canceled += ctx => moveDirection = Vector2.zero;*/
    }


	void Update()
    {
        float horizontal = moveDirection.x * Time.deltaTime * horispeed;
        float vertical = moveDirection.y * Time.deltaTime * verspeed;

        transform.Translate(horizontal, 0, vertical);

        //transform.Translate(_moveVec * _moveSpeed * Time.deltaTime);
    }

    void MoveUp()
    {
        float vertical = moveDirection.y * Time.deltaTime * verspeed;

        transform.Translate(0, 0, vertical);
    }

    public void OnMovement(InputValue input)
    {
        

        //Vector2 inputVec = input.Get<Vector2>();

        //_moveVec = new Vector3(inputVec.x, inputVec.y, 0);
    }
}
