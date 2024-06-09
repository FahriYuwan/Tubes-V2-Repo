using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Grabbable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public int type;
    [HideInInspector] public Transform originalParent;
    GameObject duplicate;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        if (originalParent.GetComponent<SlotManager>() == null)
        {
            duplicate = Instantiate(gameObject, transform.position, transform.rotation);
            duplicate.transform.SetParent(originalParent);
            Image duplicateImage = duplicate.GetComponent<Image>();
            if (duplicateImage != null)
            {
                duplicateImage.raycastTarget = true;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        image.raycastTarget = true;
        // if parent of this object doesnt have slotManager, destroy clone object
        if (originalParent.GetComponent<SlotManager>() == null)
        {
            Destroy(duplicate);
        }
    }
}