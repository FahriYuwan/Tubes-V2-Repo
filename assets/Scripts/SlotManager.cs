using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        // check if dropped object has a Grabbable component
        if (!droppedObject.GetComponent<Grabbable>())
        {
            Debug.Log("No Grabbable component found");
            return;
        }
        // set scale to 0.65f
        droppedObject.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        Grabbable grabbable = droppedObject.GetComponent<Grabbable>();
        grabbable.originalParent = transform;
        // get the card manager from parent
        CardManager cardManager = transform.parent.GetComponent<CardManager>();
        // check the card type, insert the int type to the list
        cardManager.cards.Add(grabbable.type);
        if (cardManager.cards.Count > 4)
        {
            // clone this object
            GameObject clone = Instantiate(gameObject, transform.parent);
            // get parent of this object
            Transform parent = transform.parent;
            // add 400 to its width
            parent.GetComponent<RectTransform>().sizeDelta += new Vector2(400, 0);
        }
    }
}
