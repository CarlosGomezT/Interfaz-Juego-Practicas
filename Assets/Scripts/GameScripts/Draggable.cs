using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform returnTo = null;
    public Transform placeHolderParent = null;

    private GameObject placeHolder = null;

    private float lerpTime = 0.5f; 
    private Vector3 originalPosition; 
    private bool isDragging = false;
    public bool IsForWin;

    public void OnBeginDrag(PointerEventData eventData)
    {
        DrawManagerScript.WallHit += ReleaseDragItem;
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent);
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        returnTo = this.transform.parent;
        placeHolderParent = returnTo;
        this.transform.SetParent(this.transform.parent.parent);

        this.GetComponent<CanvasGroup>().blocksRaycasts = false;

        originalPosition = transform.position;
        isDragging = true;

    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;

        if (placeHolder.transform.parent != placeHolderParent)
        {
            placeHolder.transform.SetParent(placeHolderParent);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ReleaseDragItem();
    }


    IEnumerator MoveToOriginalPosition()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        isDragging = false;
        while (elapsedTime < lerpTime)
        {

            transform.position = Vector3.Lerp(startPosition, originalPosition, (elapsedTime / lerpTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;
        isDragging = false;
    }

    private void ReleaseDragItem()
    {
        DrawManagerScript.WallHit -= ReleaseDragItem;

        this.transform.SetParent(returnTo);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeHolder);

        if (returnTo.CompareTag("DropZone")) 
        {
            DropZone dropZone = returnTo.GetComponent<DropZone>();
        }
        else
        {
            StartCoroutine(MoveToOriginalPosition());
        }
    }
}
