using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static bool Victory;
    public static bool IsPaused;
    public static int WinCondition;

    public delegate void WinEvent();
    public static event WinEvent WinConditionYes;

    //Linea de prueba para Git
    void Start()
    {
        WinConditionYes = delegate { };
        WinCondition = 1;
        IsPaused = false;
        Victory = false;
    }

    public static void TogglePauseState()
    {
        IsPaused = !IsPaused;
    }

    public static void StartWinScreen()
    {
        if (WinConditionYes != null)
        {
            WinConditionYes();
        }
    }
}
