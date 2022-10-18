using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TutorialText : MonoBehaviour
{

    public float seconds = 0.8f;
    public Camera tutorialCam;
    public GameObject videoTutorial;
    public GameObject triggerTut;
  

    // Start is called before the first frame update
    void Start()
    {
        tutorialCam.gameObject.SetActive(false);
        videoTutorial.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorialCam.gameObject.SetActive(true);
            videoTutorial.SetActive(true);
            Invoke("FinishedVideo", 8f);
        }
        //Invoke("FinishedVideo", 8f);
    }


    public void FinishedVideo()
    {
        tutorialCam.gameObject.SetActive(false);
        videoTutorial.SetActive(false);
        triggerTut.SetActive(false);
    }

}
