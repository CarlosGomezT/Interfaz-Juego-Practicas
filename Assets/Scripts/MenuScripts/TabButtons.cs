using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButtons : MonoBehaviour
{
    public List<TabPress> tabPresses;
    public Sprite TabIdle;
    public Sprite TabActive;
    public TabPress SelectedTab;
    public List<GameObject> TabsToSwap;
    public TabFilter Filter;

    public void Subscribe(TabPress button)
    {
        if (tabPresses == null)
        {
            tabPresses = new List<TabPress>();
        }
        tabPresses.Add(button);
    }


    public void OnTabSelected(TabPress button)
    {
        SelectedTab = button;
        ResetTabs();
        button.BgImage.sprite = TabActive;

        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < TabsToSwap.Count; i++)
        {
            if (i == index)
            {
                TabsToSwap[i].SetActive(true);
            }

            else 
            {
                TabsToSwap[i].SetActive(false);
            }
        }
        Filter.LookElementInScene();
        Filter.ActivateButtons();
    }
    public void ResetTabs()
    {
        foreach(TabPress button in tabPresses)
        {
            if(SelectedTab != null && button== SelectedTab)
            {
                continue;
            }
            button.BgImage.sprite = TabIdle;
        }
    }
}
