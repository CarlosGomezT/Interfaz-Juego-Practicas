using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadedLevelManger : MonoBehaviour
{
    public int LevelToLoad;
    public GameObject[] LevelListToShow;
    public int LevelUpLimit;

    void Start()
    {
        LevelToLoad = UICompletedLevels.selectedLevel;
        LevelListToShow[LevelToLoad].SetActive(true);
    }
    public void ChangeLevel(bool siguiente)
    {
        if (siguiente==true) 
        {
            if (LevelToLoad < LevelListToShow.Count())
            { 
                LevelToLoad++;
            }
            else
            {
                Debug.Log("No hay mas niveles arriba");
            }
        }
        else
        {
            if (LevelToLoad > 0)
            {
                LevelToLoad--;
            }
            else
            {
                Debug.Log("No hay mas niveles abajo");
            }
        }

        UICompletedLevels.selectedLevel = LevelToLoad;
        SceneManager.LoadScene("EscenaJuego");
    }

}
