using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileDelete : MonoBehaviour
{
    public void DeleteElement()
    {
        ProfileStorage.s_currentProfile = ProfileStorage.LoadProfile(ProfileStorage.GetFirstIndex());
        ProfileStorage.DeleteProfile(ProfileStorage.s_currentProfile.fileName);

    }
}
