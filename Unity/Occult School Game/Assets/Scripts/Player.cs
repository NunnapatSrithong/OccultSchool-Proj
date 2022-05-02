using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //The movement is refered to camera.

    [SerializeField] private CharacterController controller;
    [SerializeField] Vector3 forward;
    [SerializeField] Vector3 right;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 rightMovement = right * playerSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * playerSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        controller.Move(heading * Time.deltaTime * playerSpeed);

        if (heading != Vector3.zero)
        {
            transform.forward = heading;
        }
    }
}
