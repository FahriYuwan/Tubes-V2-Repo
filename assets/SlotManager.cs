using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        // set scale to 0.65f
        droppedObject.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        Grabbable grabbable = droppedObject.GetComponent<Grabbable>();
        grabbable.originalParent = transform;
        // get the card manager from parent
        CardManager cardManager = transform.parent.GetComponent<CardManager>();
        // check the card type, insert the int type to the list
        cardManager.cards.Add(grabbable.type);

    }
}
