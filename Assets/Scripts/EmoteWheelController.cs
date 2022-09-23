using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoteWheelController : MonoBehaviour
{
    private bool emoteWheelSelected = false;

    public Image selectedEmote;
    public Sprite noImage;
    public static int emoteID;
    

    
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            emoteWheelSelected = !emoteWheelSelected;
        }

        if (emoteWheelSelected)
        {

        }
        else
        {

        }
        switch (emoteID)
        {
            case 0:
                selectedEmote.sprite = noImage;
                break;
            case 1:
                break;
        }

    }
}
