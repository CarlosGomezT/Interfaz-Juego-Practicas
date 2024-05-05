using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelStats : MonoBehaviour
{
    public ProfileData UserData;
    public TMP_Text RecordPause;
    public TMP_Text RecordResume;
    public TMP_Text RecordWinScreen;
    public GameTime FinalTime;
    private void Start()
    {
        UserData = ProfileStorage.LoadProfile(ProfileStorage.GetFirstIndex());

        Stats.WinConditionYes += LoadWinxHS;
    }
    public void LoadPauseHS()
    {
        float record = UserData.TotalActividades[UICompletedLevels.selectedLevel].tiempoRecord;
        Debug.Log(UICompletedLevels.selectedLevel);

        if (record == 0)
        {
            RecordPause.text = ("No hay record");
        }
        else
        {
            RecordPause.text = string.Format("Record : " + DisplayTime(record));
        }
    }
    public void LoadWinxHS()
    {
        float record = UserData.TotalActividades[UICompletedLevels.selectedLevel].tiempoRecord;
        Debug.Log(UserData.TotalActividades[UICompletedLevels.selectedLevel].tiempoRecord);

        if (record > FinalTime.timeElapsed || record == 0)
        {
            RecordResume.text = string.Format("Nuevo Record : " + DisplayTime(FinalTime.timeElapsed));
            if (record == 0)
            {
                RecordWinScreen.text = string.Format("Sin record anterior");
            }
            else
            {
                RecordWinScreen.text = string.Format("Tiempo anterior : " + DisplayTime(record));
            }
            UpdateRecordTime(FinalTime.timeElapsed);
        }
        else
        {
            RecordResume.text = string.Format("Completado en: " + DisplayTime(FinalTime.timeElapsed));
            RecordWinScreen.text = string.Format("Tiempo Record : " + DisplayTime(record));
        }
    }
    public void UpdateRecordTime(float TimeToSave)
    {
        UserData.TotalActividades[UICompletedLevels.selectedLevel].tiempoRecord = TimeToSave;
        UserData.TotalActividades[UICompletedLevels.selectedLevel].terminado = true;
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
