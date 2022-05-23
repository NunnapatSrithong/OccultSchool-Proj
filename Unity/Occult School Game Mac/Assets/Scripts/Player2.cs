using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{


    [SerializeField] private CharacterController controller;
    [SerializeField] Vector3 forward;
    [SerializeField] Vector3 right;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
   

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        forward = transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = transform.right;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));

        Vector3 rightMovement = right * playerSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 upMovement = forward * playerSpeed * Time.deltaTime * -Input.GetAxis("Horizontal");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        controller.Move(heading * Time.deltaTime * playerSpeed);

        if(heading != Vector3.zero)
        {
            transform.forward = heading;
        }
        

        
    }
}