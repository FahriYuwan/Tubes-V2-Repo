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

        // check if original parent of dropped object has a SlotManager component
        if (droppedObject.GetComponent<Grabbable>().originalParent.GetComponent<SlotManager>())
        {
            Debug.Log("Original parent has SlotManager component");
        } else {
            // clone this object
            GameObject clone = Instantiate(gameObject, transform.parent);
            // get parent of this object
            Transform parent = transform.parent;
            // add 400 to its width
            parent.GetComponent<RectTransform>().sizeDelta += new Vector2(400, 0);
        }

        droppedObject.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        Grabbable grabbable = droppedObject.GetComponent<Grabbable>();
        grabbable.originalParent = transform;

        if (transform.childCount > 1)
        {
            // get the last child
            Transform lastChild = transform.GetChild(transform.childCount - 1);
            // change its sibling index to 0
            lastChild.SetSiblingIndex(0);
        }
    }
}
