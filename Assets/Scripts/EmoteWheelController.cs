using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoteWheelController : MonoBehaviour
{
    private bool emoteWheelSelected = false;
    public Animator anim;
    public Image selectedEmote;
    public Sprite noImage;
    public static int emoteID;
    public GameObject localPlayer;


    
    void Update()
    {
        localPlayer = GameObject.FindGameObjectWithTag("Player");

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
                StartCoroutine(localPlayer.GetComponent<PlayerEmotes>().JumpEmote());
                break;
            case 2:
                StartCoroutine(localPlayer.GetComponent<PlayerEmotes>().StopEmote());
                break;
            case 3:
                StartCoroutine(localPlayer.GetComponent<PlayerEmotes>().PushEmote());
                break;
            case 4:
                StartCoroutine(localPlayer.GetComponent<PlayerEmotes>().FollowEmote());
                break;
        }

    }
    
}
