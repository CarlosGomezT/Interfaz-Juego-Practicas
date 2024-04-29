using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static bool Victory;
    public static bool IsPaused;
    public static int WinCondition;

    void Start()
    {
        WinCondition = 1;
        IsPaused = false;
        Victory = false;
    }

    public static void TogglePauseState()
    {
        IsPaused = !IsPaused;
    }
}
