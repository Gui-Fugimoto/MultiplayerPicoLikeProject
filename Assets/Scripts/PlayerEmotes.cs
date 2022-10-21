using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class PlayerEmotes : NetworkBehaviour
{
    public GameObject stopImage;
    public GameObject pushImage;
    public GameObject followImage;
    public GameObject jumpImage;
    void Start()
    {
        stopImage.SetActive(false);
        pushImage.SetActive(false);
        followImage.SetActive(false);
        jumpImage.SetActive(false);
        
    }
    
    [Command]
    void CMD_ResetEmotes()
    {
        RPC_ResetEmotes();
    }

    [ClientRpc]
    void RPC_ResetEmotes()
    {
        
        stopImage.SetActive(false);
        pushImage.SetActive(false);
        followImage.SetActive(false);

        jumpImage.SetActive(false);
    }
    void ResetEmotes()
    {

        CMD_ResetEmotes();
    }

    [Command]
    void CMD_StopEmote()
    {

        RPC_StopEmote();
    }

    [ClientRpc]
    void RPC_StopEmote()
    {
        stopImage.SetActive(true); 

    }
    
    public IEnumerator StopEmote()
    {

        ResetEmotes();
        yield return new WaitForSeconds(.1f);
        CMD_StopEmote();
        Debug.Log("foi");
        yield return new WaitForSeconds(5f);
        ResetEmotes();
    }

    [Command]
    void CMD_PushEmote()
    {

        RPC_PushEmote();
    }

    [ClientRpc]
    void RPC_PushEmote()
    {
        pushImage.SetActive(true);

    }
    public IEnumerator PushEmote()
    {
        ResetEmotes();
        yield return new WaitForSeconds(.1f);
        CMD_PushEmote();
        yield return new WaitForSeconds(5f);
        ResetEmotes();
    }

    [Command]
    void CMD_FollowEmote()
    {

        RPC_FollowEmote();
    }

    [ClientRpc]
    void RPC_FollowEmote()
    {
        followImage.SetActive(true);

    }
    public IEnumerator FollowEmote()
    {
        ResetEmotes();
        yield return new WaitForSeconds(.1f);
        CMD_FollowEmote();
        yield return new WaitForSeconds(5f);
        ResetEmotes();
    }

    [Command]
    void CMD_JumpEmote()
    {

        RPC_JumpEmote();
    }

    [ClientRpc]
    void RPC_JumpEmote()
    {
        jumpImage.SetActive(true);

    }
    public IEnumerator JumpEmote()
    {
        ResetEmotes();
        yield return new WaitForSeconds(.1f);
        CMD_JumpEmote();


        yield return new WaitForSeconds(5f);
        ResetEmotes();

    }

}
