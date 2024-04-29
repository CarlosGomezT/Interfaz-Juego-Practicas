using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileList : MonoBehaviour
{
    public RectTransform rectTransform;
    public Transform profilesHolder;
    public GameObject ProfileUIBoxPrefab;
    public Sprite StarEmpty;
    public Sprite StarHecha;

    private void Start()
    {
    }

    public void LoadList()
    {
        foreach (Transform child in profilesHolder)
        {
            Destroy(child.gameObject);
        }

        var index = ProfileStorage.GetProfileIndex();

        ContainerHeight(index.profileFileNames.Count);

        foreach (var profileFileName in index.profileFileNames)
        {
            var profile = ProfileStorage.LoadProfile(profileFileName);
            if (profile != null)
            {
                var go = Instantiate(this.ProfileUIBoxPrefab);
                var uibox = go.GetComponent<UIProfileBox>();

                uibox.nameLabel.text = profile.name;
                uibox.genderLabel.text = profile.gender ;
                uibox.edadLabel.text = "Edad " + profile.age;

                for (int i = 0; i < uibox.contenedorEstrellas.transform.childCount; i++)
                {
                    Transform child = uibox.contenedorEstrellas.transform.GetChild(i);
                    Image imageStar = child.GetComponent<Image>();
                    
                    if (profile.libros[i]==false)
                    {
                        imageStar.sprite = StarEmpty;
                    }
                    else
                    {
                        imageStar.sprite = StarHecha;
                    }
                }
                go.transform.SetParent(this.profilesHolder, false);
            }
        }
    }
    public void ClearList()
    {
        foreach (Transform child in profilesHolder)
        {
            Destroy(child.gameObject);
        }

    }

    public void UpdateList()
    {
        ClearList();
        LoadList();
    }
    public void ContainerHeight(int containersCount)
    {
        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, containersCount*200);
    }
}
