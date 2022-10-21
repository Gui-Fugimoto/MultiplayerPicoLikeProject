using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class ChooseName : NetworkBehaviour
{
    public GameObject player;
    public Text chooseNameText;

    // Start is called before the first frame update
    [Command(requiresAuthority = false)]
    void CMD_NameConfirm(PlayerMovement playerMovementScript)
    {
        RPC_NameConfirm(playerMovementScript);
        print("dota3");
    }
    [ClientRpc]
    void RPC_NameConfirm(PlayerMovement playerMovementScript)
    {
        playerMovementScript.playerNameText.text = chooseNameText.text;
        print("dota4");
    }
    
    

    public void NameConfirm()
    {
        PlayerMovement varPlayerMovement = player.GetComponent<PlayerMovement>();
        CMD_NameConfirm(varPlayerMovement);
        
        Debug.Log("ACFS");
        gameObject.SetActive(false);
    }
    
}
