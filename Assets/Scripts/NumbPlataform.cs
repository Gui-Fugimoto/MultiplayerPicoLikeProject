using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumbPlataform : MonoBehaviour
{
    public bool MoveRight;
    public float speed;

    public int numPlayerOnTop;
    public int numForActivation;

    void Start()
    {
        
    }


    void Update()
    {
        if(numForActivation == numPlayerOnTop)
        {
            MovePlatform();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numPlayerOnTop += 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            numPlayerOnTop -= 1;
        }
    }
    void MovePlatform()
    {
        if(MoveRight == true)
        {
            transform.Translate(new Vector3(0, 0, -speed) * Time.deltaTime);
        }
    }
}
