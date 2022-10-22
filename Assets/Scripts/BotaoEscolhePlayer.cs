using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BotaoEscolhePlayer : MonoBehaviour
{
    public GameObject player;
    public void EscolheBesouro()
    {
        player.GetComponent<ChoosePlayerMesh>().ChooseBesouro();
    }

    public void EscolheAbelha()
    {
        player.GetComponent<ChoosePlayerMesh>().ChooseAbelha();
    }

    public void EscolheJoaninha()
    {
        player.GetComponent<ChoosePlayerMesh>().ChooseJoaninha();
    }

    public void EscolheFormiga()
    {
        player.GetComponent<ChoosePlayerMesh>().ChooseFormiga();
    }
}
