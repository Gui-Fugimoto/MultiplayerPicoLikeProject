using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class HostConnect : MonoBehaviour
{
    NetworkManager manager;
    public InputField ip_InputField;
    public GameObject HostConnect_go;

    private void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    public void HostFunction()
    {
        manager.StartHost();

        HostConnect_go.SetActive(false);
    }

    public void ConnectFunction()
    {
        manager.networkAddress = ip_InputField.text;
        manager.StartClient();

        HostConnect_go.SetActive(false);
    }
}
