using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICompletedLevels : MonoBehaviour
{
    public ProfileData UserData;
    public static int selectedLevel;

    private void Start()
    {
        LoadProfileLevels();
    }
    public void LoadProfileLevels()
    {
        UserData = ProfileStorage.LoadProfile(ProfileStorage.GetFirstIndex());
    }
}
