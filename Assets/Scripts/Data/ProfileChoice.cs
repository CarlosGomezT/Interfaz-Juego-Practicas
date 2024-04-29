using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileChoice : MonoBehaviour
{
    public int position;
    public GameObject UILists;
    public UIProfileDisplay GameManager;
    public ProfileList _ProfileList;

    void Start()
    {
        position = transform.GetSiblingIndex();
    }

    public void CallIndexPositionSwap()
    {
        UILists = GameObject.FindGameObjectWithTag("List");
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIProfileDisplay>();
        _ProfileList = GameObject.FindGameObjectWithTag("ListYes").GetComponent<ProfileList>();


        if (ProfileStorage.MakeProfileFirst(position) == true)
        {
            UILists.GetComponent<UICanvas>().CanvaHideOrShow.SetActive(true);
            GameManager.UpdateInScreen();
        }
        else
        {
            UILists.GetComponent<UICanvas>().NextCanva.SetActive(true);
        }
        UILists.SetActive(false);

        _ProfileList.ClearList();
    }
}
