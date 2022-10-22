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

    // Update is called once per frame
    
    public void ChooseAbelha()
    {
        besouro.SetActive(false);
        abelha.SetActive(true);
        joaninha.SetActive(false);
        formiga.SetActive(false);
    }
    public void ChooseJoaninha()
    {
        besouro.SetActive(false);
        abelha.SetActive(false);
        joaninha.SetActive(true);
        formiga.SetActive(false);
    }
    public void ChooseFormiga()
    {
        besouro.SetActive(false);
        abelha.SetActive(false);
        joaninha.SetActive(false);
        formiga.SetActive(true);
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
}
