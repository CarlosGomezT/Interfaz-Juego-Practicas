using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UICanvas : MonoBehaviour
{
    public GameObject CanvaHideOrShow;
    public GameObject NextCanva;
    public string levelToLoad = "MainMenu";

    public void ToggleActual()
    {
        CanvaHideOrShow.SetActive(!CanvaHideOrShow.activeSelf);
        
        if (NextCanva!=null) 
        {
            NextCanva.SetActive(!NextCanva.activeSelf);
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}