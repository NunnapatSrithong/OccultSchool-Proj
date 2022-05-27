using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //The movement is refered to camera.

    public CharacterController controller;
    [SerializeField] Vector3 forward;
    [SerializeField] Vector3 right;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private Vector3 playerVelocity;

    [SerializeField] private int sprintingMultiplier = 2;
    [SerializeField] private bool isSprinting = false;
    [SerializeField] private float stamina = 5.0f;
    [SerializeField] private float maxStamina = 10.0f;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        


        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 rightMovement = right * playerSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * playerSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        if (groundedPlayer && playerVelocity.y < 0)
        {
            move.y = 0f;
        }


        if (heading != Vector3.zero)
        {
            transform.forward = heading;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting && stamina > 0)
        {
            heading *= sprintingMultiplier;

            stamina -= Time.deltaTime;
        }
        else if(!isSprinting && stamina < maxStamina)
        {
            stamina += Time.deltaTime;
            
        }

        controller.Move(heading * Time.deltaTime * playerSpeed);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }

}
