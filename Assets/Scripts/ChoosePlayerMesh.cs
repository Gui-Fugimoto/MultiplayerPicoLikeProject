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

    [SyncVar]
    public bool ehBesouro = false;
    [SyncVar]
    public bool ehAbelha = false;
    [SyncVar]
    public bool ehJoaninha = false;
    [SyncVar]
    public bool ehFormiga = false;
    // Start is called before the first frame update
    void Start()
    {
        besouro.SetActive(true);
        abelha.SetActive(false);
        joaninha.SetActive(false);
        formiga.SetActive(false);

        


        if (ehBesouro == true)
        {
            besouro.SetActive(true);
            abelha.SetActive(false);
            joaninha.SetActive(false);
            formiga.SetActive(false);
        }
        if (ehAbelha == true)
        {
            besouro.SetActive(false);
            abelha.SetActive(true);
            joaninha.SetActive(false);
            formiga.SetActive(false);
        }
        if (ehJoaninha == true)
        {
            besouro.SetActive(false);
            abelha.SetActive(false);
            joaninha.SetActive(true);
            formiga.SetActive(false);
        }
        if (ehFormiga == true)
        {
            besouro.SetActive(false);
            abelha.SetActive(false);
            joaninha.SetActive(false);
            formiga.SetActive(true);
        }
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

        ehBesouro = true;
        ehAbelha = false;
        ehJoaninha = false;
        ehFormiga = false;
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

        ehBesouro = false;
        ehAbelha = true;
        ehJoaninha = false;
        ehFormiga = false;
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

        ehBesouro = false;
        ehAbelha = false;
        ehJoaninha = true;
        ehFormiga = false;
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

        ehBesouro = false;
        ehAbelha = false;
        ehJoaninha = false;
        ehFormiga = true;
    }
    public void ChooseFormiga()
    {
        CMD_ChooseFormiga();
    }

    
}
