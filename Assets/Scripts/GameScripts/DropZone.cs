using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    private Image previewImage; 
    public bool Dropable;
    public int GameCondition = 0;
    [SerializeField] public InGameUI UIGame;


    private void Start()
    {
        GameCondition = 0;

        previewImage = GetComponentInChildren<Image>();
        if (previewImage != null)
        {
            previewImage.enabled = false;
        }
    }
    public void OnPointerEnter(PointerEventData eventData) {

        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && Dropable == true)
        {
            d.placeHolderParent = this.transform;

            if (previewImage != null)
            {
                previewImage.enabled = true;
                previewImage.sprite = d.GetComponent<Image>().sprite;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        if (Dropable == true)
            { 
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null && d.placeHolderParent == this.transform)
            {
                d.placeHolderParent = d.returnTo;
            }

            if (previewImage != null)
            {
                previewImage.enabled = false;
            }
        }
    }


    public void OnDrop(PointerEventData eventData) 
    {        
        if (Dropable == true) 
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null) {

                if (d.IsForWin)
                {
                    d.returnTo = this.transform;
                    GameCondition++;
                }
            }

            if (previewImage != null)
            {
                previewImage.enabled = false;
            }
        }

        if (GameCondition >= Stats.WinCondition)
        {
            //if (Stats.Victory == true)
            //{
            //    WinUiGame();
            //} 
            //
            UIGame.WinUiGame();
        }
    }
}

