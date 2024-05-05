using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelToLoad;
    public int Tag;
    public UICompletedLevels UserLevelsDisplay;
    public Image EstrellaTerminado;
    private void Start()
    {
        DisplayCompleted();
    }
    public void LoadSelectedLevel()
    {

    }
    public void DisplayCompleted()
    {
        if (UserLevelsDisplay.UserData.TotalActividades[levelToLoad].terminado == true)
        {
            EstrellaTerminado.enabled = true;
            Debug.Log("Nivel Terminado");
        }
        else
        {
            EstrellaTerminado.enabled = false;
            Debug.Log("Nivel sin terminar");
        }
    }

    public void OpenScene ()
    {
        UICompletedLevels.selectedLevel = levelToLoad;
        SceneManager.LoadScene("EscenaJuego");
    }
}
