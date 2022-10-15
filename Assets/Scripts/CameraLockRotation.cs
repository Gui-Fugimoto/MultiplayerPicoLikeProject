using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockRotation : MonoBehaviour
{
    public GameObject player;
    Quaternion rotation;
    void Awake()
    {
        rotation = this.transform.rotation;
    }
    void LateUpdate()
    {
        this.transform.rotation = rotation;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5.5f, player.transform.position.z - 14);
    }
}
