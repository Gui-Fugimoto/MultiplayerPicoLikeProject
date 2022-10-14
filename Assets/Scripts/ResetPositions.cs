using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositions : MonoBehaviour
{
    public Vector3 initialPos;
    
    void Start()
    {
        initialPos = gameObject.transform.position;
    }



    public void ResetPosition()
    {
        gameObject.transform.position = initialPos;
        //Debug.Log("Resetei");
    }
}
