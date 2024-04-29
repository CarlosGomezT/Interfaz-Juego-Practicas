using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TabFilter : MonoBehaviour
{
    public List<TabFilterButtons> filterButtons;
    public Sprite TabIdle;
    public Sprite TabActive;
    public GameObject FilterGroup;  
    public List<TabFilterButtons> buttonsInFilter;
    public List<GameObject> elementsInScene;
    public GameObject activeTab;

    public void Start()
    {
        for (int i = 0; i < FilterGroup.transform.childCount; i++)
        {
            buttonsInFilter.Add(FilterGroup.transform.GetChild(i).GetComponent<TabFilterButtons>());
        }
        LookElementInScene();
    }
    public void Subscribe(TabFilterButtons button)
    {
        if (filterButtons == null)
        {
            filterButtons = new List<TabFilterButtons>();
        }
        filterButtons.Add(button);
    }
    public void OnFilterSelected(TabFilterButtons button)
    {
        if (button.Selected)
        {
            button.BgImage.sprite = TabActive;
        }
        else
        {
            button.BgImage.sprite= TabIdle;
        }

        ActivateButtons();
    }
    public void ResetTabs()
    {
        foreach (TabFilterButtons button in filterButtons)
        {
            button.BgImage.sprite = TabIdle;
        }
    }
    public void LookElementInScene()
    {
        elementsInScene.Clear();
        try
        {
            activeTab = GameObject.FindGameObjectWithTag("ButtonMenu");
            for (int i = 0; i < activeTab.transform.childCount; i++)
            {
                elementsInScene.Add(activeTab.transform.GetChild(i).gameObject);
            }
            foreach (GameObject hijo in elementsInScene)
            {
                Debug.Log("Nombre del hijo: " + hijo.name);
            }
        }
        catch {
            Debug.Log("No se encontro ningun objeto");
            return; 
        }
    }
    private void ShowTaggedItems(int TagFilter)
    {
        foreach (GameObject botonesEnEscena in elementsInScene)
        {
            LevelButton _levelButton = botonesEnEscena.GetComponent<LevelButton>();

            if (_levelButton != null)
            {
                if (_levelButton.Tag == TagFilter)
                {
                    botonesEnEscena.SetActive(true);
                }
            }
            else
            {
                Debug.LogWarning("El hijo " + botonesEnEscena.name + " no tiene el componente LevelButton.");
            }
        }
    }
    private void HideAllItems(bool AnySelected)
    {
        foreach (GameObject botonesEnEscena in elementsInScene)
        {
            LevelButton _levelButton = botonesEnEscena.GetComponent<LevelButton>();

            if (_levelButton != null)
            {
                    botonesEnEscena.SetActive(!AnySelected);
            }
        }
    }

    public bool CheckFilterSelectedStatus()
    {
        foreach (var button in buttonsInFilter)
        {
            if (button.Selected)
            {
                return true;
            }
        }
        return false;
    } 
    public void ActivateButtons()
    {
        HideAllItems(CheckFilterSelectedStatus());
        foreach (TabFilterButtons _filterButton in buttonsInFilter)
        {
            if (_filterButton.Selected)
            {
                ShowTaggedItems(_filterButton.TagSelected);
            }
        }
    }
}