using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    ResetPositions[] resetList;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            resetList = FindObjectsOfType<ResetPositions>();
            if (resetList != null) 
                for(int i = 0; i < resetList.Length; i++)
            {
                resetList[i].gameObject.GetComponent<ResetPositions>().ResetPosition();
                    
            }       

        }
    }
}
