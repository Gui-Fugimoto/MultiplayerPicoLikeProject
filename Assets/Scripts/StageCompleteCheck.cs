using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageCompleteCheck : MonoBehaviour
{
    public int fruitsTaken;
    public string sceneName;
    void Update()
    {
        if (fruitsTaken == 4)
        {
            StageComplete();
        }
    }
    public void StageComplete()
    {
        SceneManager.LoadScene(sceneName);
    }

}
