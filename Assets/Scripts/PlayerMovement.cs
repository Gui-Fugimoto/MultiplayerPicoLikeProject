using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = 10f;
    public float jumpSpeed = 3.5f;

    public Camera playerCamera;
    public Transform cam;
    private StageCompleteCheck stageCompleteGameObject;

    private CharacterController controller;

    private float directionY;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool gotFruit = false;
   

    [SyncVar]
    public string nomeVar;

    public TextMesh playerNameText;
    //public Canvas respawn;

    public GameObject player;
    //public bool isDead;

    public Animator anim;

    public GameObject canvasChooseName;



    [SerializeField] private float movSpeed = 2f;

    
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        //anim = GetComponent<Animator>();
        //respawn.enabled = false;
        
        Debug.Log("entrou no jogo");
        stageCompleteGameObject = FindObjectOfType<StageCompleteCheck>();
        //stageCompleteGameObject.GetComponent<StageCompleteCheck>().playerNum++;
        //stageCompleteGameObject.GetComponent<StageCompleteCheck>().gameStarted = true;
        stageCompleteGameObject.GetComponent<StageCompleteCheck>().ResetFruits();
        if (!isLocalPlayer)
        {
            playerNameText.text = nomeVar;
            playerCamera.gameObject.SetActive(false);
        }        
        
    }
    [Command(requiresAuthority = false)]
    public void CMD_NameConfirm(PlayerMovement playerMovementScript, string nome54)
    {
        RPC_NameConfirm(playerMovementScript, nome54);
        print("dota3");
    }
    [ClientRpc]
    void RPC_NameConfirm(PlayerMovement playerMovementScript, string nome54)
    {
        
        playerMovementScript.playerNameText.text = nome54;
        nomeVar = nome54;
        print("dota4");
    }
    
    public override void OnStartLocalPlayer()
    {
        canvasChooseName.SetActive(true);

        TestifDota();
        Debug.Log("ENTROU no jogo");
        base.OnStartLocalPlayer();
        FindObjectOfType<EmoteWheelController>().localPlayer = gameObject;
    }
    [Command(requiresAuthority = false)]
    void TestifDota()
    {
        StartCoroutine(StartGameCount());
    }
    IEnumerator StartGameCount()
    {
        yield return new WaitForSeconds(0.1f);
        stageCompleteGameObject.GetComponent<StageCompleteCheck>().playerNum++;

        yield return new WaitForSeconds(0.2f);
        stageCompleteGameObject.GetComponent<StageCompleteCheck>().gameStarted = true;
        stageCompleteGameObject.GetComponent<StageCompleteCheck>().ResetFruits();
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

        anim.SetFloat("Speed", direction.magnitude);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                directionY = jumpSpeed;
            }
        }
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            anim.SetBool("animWalk", true);
        }
        else
        {
            anim.SetBool("animWalk", false);
        }
        

        directionY -= gravity * Time.deltaTime;

        direction.y = directionY;
        controller.Move(direction * moveSpeed * Time.deltaTime);
        
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {           
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            other.transform.parent = null;
        }
    }
    */
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            isDead = true;
            player.SetActive(false);
            //Invoke("PlayerRespawn", 10f);
        }
    }

    public void PlayerRespawn()
    {
        if (isDead)
        {
            //player.SetActive(true);
            //Instantiate(player,new Vector3(-1.027588f,1,-12.07064f),Quaternion.identity);
        }
    }
    */
}
    