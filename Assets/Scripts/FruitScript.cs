using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{

    public GameObject stageCompleteCheck;

    
    void Update()
    {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!other.GetComponent<PlayerMovement>().gotFruit)
            {
                stageCompleteCheck.GetComponent<StageCompleteCheck>().fruitsTaken++;
                other.GetComponent<PlayerMovement>().gotFruit = true;
                Destroy(gameObject, .1f);
            }

        }
    }
}
