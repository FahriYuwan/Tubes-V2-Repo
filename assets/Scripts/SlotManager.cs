using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotManager : MonoBehaviour, IDropHandler
{
    public int droppedIndex;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        droppedObject.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        Grabbable grabbable = droppedObject.GetComponent<Grabbable>();

        // check if dropped object has a Grabbable component
        if (!droppedObject.GetComponent<Grabbable>())
        {
            Debug.Log("No Grabbable component found");
            return;
        }

        // check if original parent of dropped object has a SlotManager component
        if (droppedObject.GetComponent<Grabbable>().originalParent.GetComponent<SlotManager>())
        {
            Debug.Log("Original parent has SlotManager component");
            droppedIndex = grabbable.originalParent.GetSiblingIndex();

        } else {
            try {
                Transform card = transform.GetChild(0);
                card.SetParent(null);

                // clone this object
                GameObject clone = Instantiate(gameObject, transform.parent);
                // get parent of this object
                Transform parent = transform.parent;
                // add 400 to its width
                parent.GetComponent<RectTransform>().sizeDelta += new Vector2(400, 0);

                card.SetParent(transform);

                droppedIndex = -1;
            } catch (System.Exception e) {
                // clone this object
                GameObject clone = Instantiate(gameObject, transform.parent);
                // get parent of this object
                Transform parent = transform.parent;
                // add 400 to its width
                parent.GetComponent<RectTransform>().sizeDelta += new Vector2(400, 0);
            }
        }

        grabbable.originalParent = transform;

        if (transform.childCount >= 1)
        {
            // trigger shiftCards coroutine in CardManager
            // get the index of the dropped object
            int index = transform.GetSiblingIndex();
            Debug.Log("Index: " + index);
            Debug.Log("Dropped index: " + droppedIndex);
            // get the CardManager component
            CardManager cardManager = transform.parent.GetComponent<CardManager>();
            // trigger shiftCards coroutine
            cardManager.shiftCards(index, droppedIndex);
        }
    }
}
