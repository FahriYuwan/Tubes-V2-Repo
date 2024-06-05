using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Grabbable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform originalParent;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        // set scale to 1.74f
        // transform.localScale = new Vector3(1.74f, 1.74f, 1.74f);
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Stay Drag");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(originalParent);
        image.raycastTarget = true;
    }
}