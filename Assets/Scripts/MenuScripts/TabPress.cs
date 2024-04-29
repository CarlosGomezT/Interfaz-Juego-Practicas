using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TabPress : MonoBehaviour,IPointerClickHandler
{
    public TabButtons TabButtons;
    public Image BgImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        TabButtons.OnTabSelected(this);
    }
    void Start()
    {
        BgImage = GetComponent<Image>();
        TabButtons.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
