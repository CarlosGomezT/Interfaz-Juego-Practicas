using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonValidation : MonoBehaviour
{
    public TMP_InputField inputField; 
    public TMP_Dropdown[] dropdowns; 
    public Button button; 

    private void Start()
    {
        inputField.onValueChanged.AddListener(delegate { ValidateForm(); });
        foreach (TMP_Dropdown dropdown in dropdowns)
        {
            dropdown.onValueChanged.AddListener(delegate { ValidateForm(); });
        }

        button.interactable = false;
    }
    private void ValidateForm()
    {
        bool inputFilled = !string.IsNullOrEmpty(inputField.text);
        bool dropdownFilled = true;

        foreach (TMP_Dropdown dropdown in dropdowns)
        {
            if (dropdown.value == 0)
            {
                dropdownFilled = false;
                break;
            }
        }

        button.interactable = inputFilled && dropdownFilled;
    }
    public void CleanField()
    {
        inputField.text = "";
        foreach (TMP_Dropdown dropdown in dropdowns)
        {
            dropdown.value = 0;
        }
        ValidateForm();
    }
}
