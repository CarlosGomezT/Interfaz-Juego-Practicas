using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject UIPause;
    public GameObject WinUI;
    public string levelToLoad = "MainMenu";

    private void Start()
    {
        Stats.WinConditionYes += WinUiGame;
    }
    void Update()
    {

    }

    public void TogglePause()
    {
        Stats.TogglePauseState();
        UIPause.SetActive(!UIPause.activeSelf);
        if (UIPause.activeSelf)
        {
            AudioInMenu(true);
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
            AudioInMenu(false);
        }
    }
    
    public void WinUiGame()
    {
        AudioInMenu(true);
        Time.timeScale = 0f;
        WinUI.SetActive(!WinUI.activeSelf);
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelToLoad);
    }
    public void AudioInMenu(bool pause)
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        
        if(pause==true)
        {
            foreach (AudioSource audio in audios)
            {
                audio.Pause();
                //Debug.Log("audio pause");
            }
        }
        else
        {
            foreach (AudioSource audio in audios)
            {
                audio.UnPause();
                //Debug.Log("audio play");
            }
        }
    }
}
