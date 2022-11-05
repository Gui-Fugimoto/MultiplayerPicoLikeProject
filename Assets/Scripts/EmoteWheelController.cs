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
    public PlayerMovement[] localPlayerList;
    public GameObject menuCanva;
    public bool onMenu = false;
    PlayerEmotes playerEmotes;

    
    void Update()
    {
        if(localPlayer == null)
        {
            return;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            StartCoroutine(AbreMenu());
        }
        
           


        if (Input.GetKeyDown(KeyCode.Tab))
        {

            print("dota2");
            emoteWheelSelected = !emoteWheelSelected;
            /*
            localPlayerList = FindObjectsOfType<PlayerMovement>();
            localPlayer = FindObjectOfType<PlayerMovement>().gameObject;
            if (localPlayerList != null)
            {
                for (int i = 0; i < localPlayerList.Length; i++)
                {
                    localPlayerList[i] = localPlayer.GetComponent<PlayerMovement>();
                    if (!localPlayer.GetComponent<PlayerMovement>().connectEmoteWheel == true)
                    {
                        localPlayer = 
                    }
                    

                }
            }
            */
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
    IEnumerator AbreMenu()
    {
        

        if (onMenu == false)
        {
            onMenu = true;
            menuCanva.SetActive(true);
            yield return new WaitForSeconds(0.01f);
            menuCanva.GetComponent<InGameMenu>().ChangeVolume();
            Debug.Log("FNDASUIIHDFIAOU");

        }

        else if (onMenu == true)
        {

            menuCanva.GetComponent<InGameMenu>().FechaMenu();
            onMenu = false;
            Debug.Log("coringuido");
        }
    }


}
