using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class EmoteWheelController : NetworkBehaviour
{
    private bool emoteWheelSelected = false;
    public Animator anim;
    public Image selectedEmote;
    public Sprite noImage;
    public static int emoteID;
    public GameObject player;


    
    void Update()
    {
        /*
        if (isLocalPlayer)
        {
            player = GameObject.FindWithTag("Player");
        }
        */

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            emoteWheelSelected = !emoteWheelSelected;
        }

        if (emoteWheelSelected)
        {
            anim.SetBool("OpenEmoteWheel", true);
        }
        else
        {
            anim.SetBool("OpenEmoteWheel", false);
        }
        switch (emoteID)
        {
            case 0:
                selectedEmote.sprite = noImage;
                break;
            case 1:
                StartCoroutine(player.GetComponent<PlayerEmotes>().JumpEmote());
                break;
            case 2:
                StartCoroutine(player.GetComponent<PlayerEmotes>().StopEmote());
                break;
            case 3:
                StartCoroutine(player.GetComponent<PlayerEmotes>().PushEmote());
                break;
            case 4:
                StartCoroutine(player.GetComponent<PlayerEmotes>().FollowEmote());
                break;
        }

    }
}
