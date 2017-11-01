using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController CharacterController;
    //Rigidbody rigidBody;
    public float walk_Speed = 1.0f;
    public float turn_Speed = 100.0f;
    void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        //rigidBody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        // Changed the Horizontal Axis to turn left and right
        transform.Rotate(0, Input.GetAxis("Horizontal") * turn_Speed * Time.deltaTime, 0);

        float vertical = Input.GetAxis("Vertical");
        Vector3 moveForward = transform.forward * vertical * walk_Speed;
        CharacterController.SimpleMove(moveForward);
        //rigidBody.MovePosition(moveForward);

        //float horizontal = Input.GetAxis("Horizontal");
        //Vector3 moveSide = transform.forward * horizontal * walk_Speed;
        //CharacterController.SimpleMove(moveSide);
        
        /* if (Input.GetMouseButton(0))
         {
             float hori = Input.GetAxis("Horizontal");
             float vert = Input.GetAxis("Vertical");
             Vector3 moveForwardBon = transform.forward * vert * walk_Speed;
             Vector3 moveSideBon = transform.forward * hori * walk_Speed;

             CharacterController.SimpleMove(moveForwardBon);
             CharacterController.SimpleMove(moveSideBon);
         }*/
    }
}
