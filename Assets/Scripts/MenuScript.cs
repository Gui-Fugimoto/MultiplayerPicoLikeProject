using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public string stageSceneName;
    
    public void MudaCena()
    {
        SceneManager.LoadScene(stageSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
