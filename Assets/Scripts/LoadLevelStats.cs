using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelStats : MonoBehaviour
{
    public ProfileData UserData;
    public TMP_Text RecordPause;
    public TMP_Text RecordWinScreen;
    public GameTime FinalTime;
    private void Start()
    {
        UserData = ProfileStorage.LoadProfile(ProfileStorage.GetFirstIndex());

        Stats.WinConditionYes += LoadWinxHS;
    }
    public void LoadPauseHS()
    {
        float record = UserData.TotalActividades[1].tiempoRecord;
        int minutes = Mathf.FloorToInt(record / 60);
        int seconds = Mathf.FloorToInt(record % 60);
        RecordPause.text = string.Format("Record : " + DisplayTime(record));
    }
    public void LoadWinxHS()
    {
        float record = UserData.TotalActividades[1].tiempoRecord;
        Debug.Log(UserData.TotalActividades[1].tiempoRecord);

        int minutes = Mathf.FloorToInt(record / 60);
        int seconds = Mathf.FloorToInt(record % 60);

        if (record > FinalTime.timeElapsed)
        {
            RecordWinScreen.text = string.Format("Nuevo Record : " + DisplayTime(FinalTime.timeElapsed) + "\n Tiempo anterior : " + DisplayTime(record));
            UpdateRecordTime(FinalTime.timeElapsed);
        }
        else
        {
            RecordWinScreen.text = string.Format("Record : {0:00}:{1:00}", minutes, seconds);
        }
    }
    public void UpdateRecordTime(float TimeToSave)
    {
        UserData.TotalActividades[1].tiempoRecord = TimeToSave;
        ProfileStorage.s_currentProfile = UserData;
        ProfileStorage.StoreEditProfile(ProfileStorage.s_currentProfile);
    }
    public string DisplayTime(float TimeToFormat)
    {
        int minutes = Mathf.FloorToInt(TimeToFormat / 60);
        int seconds = Mathf.FloorToInt(TimeToFormat % 60);
        return string.Format("{0:00}:{1:00} ", minutes, seconds);
    }
}
