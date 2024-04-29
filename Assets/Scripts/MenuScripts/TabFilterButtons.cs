using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TabFilterButtons : MonoBehaviour, IPointerClickHandler
{
    public TabFilter filterButton;
    public Image BgImage;
    public int TagSelected;
    public bool Selected;

    void Start()
    {
        BgImage = GetComponent<Image>();
        filterButton.Subscribe(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Selected = !Selected;
        filterButton.OnFilterSelected(this);
    }

    public void UpdateShow()
    {

    }
}
