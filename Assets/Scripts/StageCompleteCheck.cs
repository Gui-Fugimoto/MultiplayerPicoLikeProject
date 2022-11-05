using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;


public enum NumOfPlayers { TWOPLAYERS, THREEPLAYERS, FOURPLAYERS}
public class StageCompleteCheck : NetworkBehaviour
{
    public int fruitsTaken;
    public string sceneName;

    [SyncVar]
    public int playerNum = 0;
   

    public bool gameStarted = false;

    public GameObject fruit1;
    public GameObject fruit2;
    public GameObject fruit3;
    public GameObject fruit4;
    public NumOfPlayers state;

    void Start()
    {
        fruit1.SetActive(true);
        fruit2.SetActive(true);
        fruit3.SetActive(false);
        fruit4.SetActive(false);

    }
    void Update()
    {
        
        if (fruitsTaken == playerNum && gameStarted == true)
        {
            StageComplete();
        }
        if (playerNum == 2)
        {
            state = NumOfPlayers.TWOPLAYERS;
        }
        if (playerNum == 3)
        {
            state = NumOfPlayers.THREEPLAYERS;
        }
        if (playerNum == 4)
        {
            state = NumOfPlayers.FOURPLAYERS;
        }
        /*
        else if (playerNum >= 5)
        {
            playerNum = 4;
            //Colocar aqui codigo para não deixar mais players spawnanrem
        }
        */

    }
    public void StageComplete()
    {
        SceneManager.LoadScene(sceneName);
    }
    void StateMachine()
    {
        switch (state)
        {
            case NumOfPlayers.TWOPLAYERS:
                ResetFruits();
                break;

            case NumOfPlayers.THREEPLAYERS:
                ResetFruits();
                break;

            case NumOfPlayers.FOURPLAYERS:
                ResetFruits();
                break;

        }
    }

    public void ResetFruits()
    {
        CMD_ResetFruits();
    }
    [Command(requiresAuthority = false)]
    void CMD_ResetFruits()
    {

        RPC_ResetFruits();
    }

    [ClientRpc]
    void RPC_ResetFruits()
    {
        if (state == NumOfPlayers.TWOPLAYERS)
        {
            fruit1.SetActive(true);
            fruit2.SetActive(true);
            fruit3.SetActive(false);
            fruit4.SetActive(false);
            Debug.Log("Fruta 2");
        }
        if (state == NumOfPlayers.THREEPLAYERS)
        {
            fruit1.SetActive(true);
            fruit2.SetActive(true);
            fruit3.SetActive(true);
            fruit4.SetActive(false);
            Debug.Log("Fruta 3");
        }
        if (state == NumOfPlayers.FOURPLAYERS)
        {
            fruit1.SetActive(true);
            fruit2.SetActive(true);
            fruit3.SetActive(true);
            fruit4.SetActive(true);
            Debug.Log("Fruta 4");
        }
    }
    
    

}
