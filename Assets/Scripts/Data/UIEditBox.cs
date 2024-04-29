using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml;
using Unity.VisualScripting;

public class UIEditBox : MonoBehaviour
{
    public TMP_InputField profileInput;
    public TMP_Dropdown ageDropDown;
    public TMP_Dropdown genderDropDown;

    public void UpdateEditScreen()
    {
        UpdateEditScreen(ProfileStorage.LoadProfile(ProfileStorage.GetFirstIndex()));
    }

    public void UpdateEditScreen(ProfileData profile)
    {
        profileInput.text = profile.name;
        genderDropDown.value = profile.gen_Value;
        ageDropDown.value = profile.age;
    }
    public void UpdateEditSlots()
    {
        ProfileStorage.s_currentProfile = ProfileStorage.LoadProfile(ProfileStorage.GetFirstIndex());

        ProfileStorage.s_currentProfile.name = this.profileInput.text;
        ProfileStorage.s_currentProfile.gender = genderDropDown.options[genderDropDown.value].text;
        ProfileStorage.s_currentProfile.gen_Value = genderDropDown.value;
        ProfileStorage.s_currentProfile.age = ageDropDown.value;


        ProfileStorage.StoreEditProfile(ProfileStorage.s_currentProfile);
    }
}
