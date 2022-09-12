using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    public GameObject fastTutorial;
   

    // Start is called before the first frame update
    void Start()
    {
        fastTutorial.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fastTutorial.SetActive(true);
        }
    }

}
