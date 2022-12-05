using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    ResetPositions[] resetList;
    PlayerMovement[] allPlayersList;
    
    public GameObject stageCompleteCheck;

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

            stageCompleteCheck.GetComponent<StageCompleteCheck>().ResetFruits();
            stageCompleteCheck.GetComponent<StageCompleteCheck>().fruitsTaken = 0;

            allPlayersList = FindObjectsOfType<PlayerMovement>();
            if (resetList != null)
                for (int i = 0; i < allPlayersList.Length; i++)
                {
                    allPlayersList[i].gameObject.GetComponent<PlayerMovement>().gotFruit = false;
                }



        }
    }
}
