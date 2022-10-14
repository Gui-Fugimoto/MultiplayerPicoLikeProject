using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositions : MonoBehaviour
{
    Vector3 initialPos;
    
    void Start()
    {
        initialPos = gameObject.transform.position;
    }



    public void ResetPosition()
    {
        gameObject.transform.position = initialPos;
    }
}
