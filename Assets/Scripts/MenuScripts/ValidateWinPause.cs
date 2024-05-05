using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateWinPause : MonoBehaviour
{
    public Button lastLevel;
    public Button nextLevel;
    public int limitNextLevel;

    private void Start()
    {
        if (UICompletedLevels.selectedLevel==0) 
        { 
            lastLevel.enabled = false;
        }

        if (UICompletedLevels.selectedLevel == limitNextLevel)
        {
            nextLevel.enabled = false;
        }

    }
}
