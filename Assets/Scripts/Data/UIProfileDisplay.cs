using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Profiling;

public class UIProfileDisplay : UIProfileBox
{
    public TextMeshProUGUI[] titleLabel;
    public Sprite StarEmpty;
    public Sprite StarHecha;

    private void Start()
    {
        UpdateOnOtherScreens();
    }
    public void UpdateInScreen()
    {
        ProfileStorage.s_currentProfile = ProfileStorage.LoadProfile(ProfileStorage.GetFirstIndex());

        nameLabel.text = "Nombre: " + ProfileStorage.s_currentProfile.name;
        genderLabel.text = "Genero: " + ProfileStorage.s_currentProfile.gender;
        edadLabel.text = "Edad: " + ProfileStorage.s_currentProfile.age;

        for (int i = 0; i < contenedorEstrellas.transform.childCount; i++)
        {
            Transform child = contenedorEstrellas.transform.GetChild(i);
            Image imageStar = child.GetComponent<Image>();

            if (ProfileStorage.s_currentProfile.libros[i] == false)
            {
                imageStar.sprite = StarEmpty;
            }
            else
            {
                imageStar.sprite = StarHecha;
            }
        }
    }

    public void UpdateSceenProfileData(ProfileData profile)
    {
        if (profile.gender == "Femenino")
        {
            titleLabel[0].text = "Bienvenida " + profile.name;

            titleLabel[1].text = "Bienvenido " + profile.name;
        }
        else
        {
            titleLabel[0].text = "Bienvenido " + profile.name;

            titleLabel[1].text = "Bienvenido " + profile.name;
        }

        nameLabel.text = "Nombre: " + profile.name;
        genderLabel.text = "Genero: " + profile.gender;
        edadLabel.text = "Edad: "+profile.age;

        for (int i = 0; i < contenedorEstrellas.transform.childCount; i++)
        {
            Transform child = contenedorEstrellas.transform.GetChild(i);
            Image imageStar = child.GetComponent<Image>();

            if (profile.libros[i] == false)
            {
                imageStar.sprite = StarEmpty;
            }
            else
            {
                imageStar.sprite = StarHecha;
            }
        }
    }
    public void UpdateOnOtherScreens()
    {
        UpdateSceenProfileData(ProfileStorage.LoadProfile(ProfileStorage.GetFirstIndex()));
    }
}
