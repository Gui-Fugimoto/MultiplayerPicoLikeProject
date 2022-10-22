using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

public class ChoosePlayerMesh : NetworkBehaviour
{
    public GameObject besouro;
    public GameObject abelha;
    public GameObject joaninha;
    public GameObject formiga;
    // Start is called before the first frame update
    void Start()
    {
        besouro.SetActive(true);
        abelha.SetActive(false);
        joaninha.SetActive(false);
        formiga.SetActive(false);
    }

    

    [Command]
    void CMD_ChooseBesouro()
    {

        RPC_ChooseBesouro();
    }
    [ClientRpc]
    void RPC_ChooseBesouro()
    {
        besouro.SetActive(true);
        abelha.SetActive(false);
        joaninha.SetActive(false);
        formiga.SetActive(false);
    }
    public void ChooseBesouro()
    {
        CMD_ChooseBesouro(); 
    }

    [Command]
    void CMD_ChooseAbelha()
    {

        RPC_ChooseAbelha();
    }
    [ClientRpc]
    void RPC_ChooseAbelha()
    {
        besouro.SetActive(false);
        abelha.SetActive(true);
        joaninha.SetActive(false);
        formiga.SetActive(false);
    }
    public void ChooseAbelha()
    {
        CMD_ChooseAbelha();
    }


    [Command]
    void CMD_ChooseJoaninha()
    {

        RPC_ChooseJoaninha();
    }
    [ClientRpc]
    void RPC_ChooseJoaninha()
    {
        besouro.SetActive(false);
        abelha.SetActive(false);
        joaninha.SetActive(true);
        formiga.SetActive(false);
    }
    public void ChooseJoaninha()
    {
        CMD_ChooseJoaninha();
    }


    [Command]
    void CMD_ChooseFormiga()
    {

        RPC_ChooseFormiga();
    }
    [ClientRpc]
    void RPC_ChooseFormiga()
    {
        besouro.SetActive(false);
        abelha.SetActive(false);
        joaninha.SetActive(false);
        formiga.SetActive(true);
    }
    public void ChooseFormiga()
    {
        CMD_ChooseFormiga();
    }
}
