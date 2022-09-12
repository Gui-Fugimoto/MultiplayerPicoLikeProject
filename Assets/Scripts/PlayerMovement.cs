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
    public Canvas respawn;

    public GameObject player;
    public bool isDead;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        //respawn.enabled = false;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            isDead = true;
            player.SetActive(false);
            respawn.enabled = (true);
        }
    }

    public void PlayerRespawn()
    {
        if (isDead)
        {
            player.SetActive(true);
        }
    }
}
    