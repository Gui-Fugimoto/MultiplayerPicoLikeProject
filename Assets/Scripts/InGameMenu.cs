using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] GameObject fundoVolume;
    
    // Start is called before the first frame update
    void Start()
    {
        fundoVolume.SetActive(false);
        
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("mudicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }
    
    public void ChangeVolume()
    {
        
        AudioListener.volume = volumeSlider.value;
        Save();
        
    }
    public void FechaMenu()
    {
        fundoVolume.SetActive(false);
        
    }
    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
