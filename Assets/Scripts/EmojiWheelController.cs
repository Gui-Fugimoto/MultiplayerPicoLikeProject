using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmojiWheelController : MonoBehaviour
{
    public int ID;
    public string emoteName;
    public Image selectedEmote;
    public TextMeshProUGUI emoteText;
    private bool selected = false;
    public Sprite icon;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            selectedEmote.sprite = icon;
            emoteText.text = emoteName;
        }

    }

    public void Selected()
    {
        selected = true;
        EmoteWheelController.emoteID = ID;
    }

    public void Deselected()
    {
        selected = false;
        EmoteWheelController.emoteID = 0;
    }
    public void HoverEnter()
    {
        emoteText.text = emoteName;
    }
    public void HoverExit()
    {
        emoteText.text = "";
    }

}
