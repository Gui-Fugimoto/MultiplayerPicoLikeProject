using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PlayerMovement : NetworkBehaviour
{
    
    

    public float moveSpeed = 5f;
    public float gravity = 10f;
    public float jumpSpeed = 3.5f;

    private CharacterController controller;

    private float directionY;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Text nameTag;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpSpeed;
            }
        }
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            
            
        }
        

        directionY -= gravity * Time.deltaTime;

        direction.y = directionY;
        controller.Move(direction * moveSpeed * Time.deltaTime);
        
    }

    
}
    