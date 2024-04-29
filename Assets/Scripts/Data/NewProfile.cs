using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class NewProfile : MonoBehaviour
{
    public TMP_InputField profileInput;
    public TMP_Dropdown genderDropDown;
    public TMP_Dropdown ageDropDown;


    public void Generate()
    {
        string profileName = this.profileInput.text;
        string genderChoice = genderDropDown.options[genderDropDown.value].text;
        int AgeChoice = ageDropDown.value;
        int DD_Gender = genderDropDown.value;


        ProfileStorage.CreateNewGame(profileName, genderChoice, AgeChoice, DD_Gender);
    }
}
