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
        // droppedObject.transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
        droppedObject.transform.localScale = new Vector3(droppedObject.transform.localScale.x * 0.75f, droppedObject.transform.localScale.y * 0.75f, droppedObject.transform.localScale.z * 0.75f);
        Grabbable grabbable = droppedObject.GetComponent<Grabbable>();
        grabbable.originalParent = transform;
        
    }
}
