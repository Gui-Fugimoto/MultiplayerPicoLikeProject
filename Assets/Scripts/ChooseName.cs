using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChooseName : MonoBehaviour
{
    public GameObject player;
    public Text chooseNameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NameConfirm()
    {
        player.GetComponent<PlayerMovement>().playerNameText.text = chooseNameText.text;
        Debug.Log("ACFS");
        gameObject.SetActive(false);
    }
}
