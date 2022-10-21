using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class PlayerEmotes : NetworkBehaviour
{
    public Image stopImage;
    public Image pushImage;
    public Image followImage;
    public Image jumpImage;
    void Start()
    {
        stopImage.enabled = false;
        pushImage.enabled = false;
        followImage.enabled = false;
        jumpImage.enabled = false;
        
    }
    
    [Command]
    void CMD_ResetEmotes()
    {
        RPC_ResetEmotes();
    }

    [ClientRpc]
    void RPC_ResetEmotes()
    {
        
        stopImage.enabled = false;
        pushImage.enabled = false;
        followImage.enabled = false;

        jumpImage.enabled = false;
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
        stopImage.enabled = true; 

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
        pushImage.enabled = true;

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
        followImage.enabled = true;

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
        jumpImage.enabled = true;

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
