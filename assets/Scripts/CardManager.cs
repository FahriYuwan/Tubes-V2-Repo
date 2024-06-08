using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // list of cards
    public List<int> cards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // constantly check grandchild of this object if there is Grabbable component in there
        foreach (Transform child in transform)
        {
            foreach (Transform grandchild in child)
            {
                if (grandchild.GetComponent<Grabbable>() != null)
                {
                    // if there is Grabbable component, check if it is grabbed
                    if (grandchild.GetComponent<Grabbable>().isGrabbed)
                    {
                        // if it is grabbed, check if it is in the list of cards
                        if (cards.Contains(grandchild.GetComponent<Grabbable>().cardNumber))
                        {
                            // if it is in the list of cards, remove it from the list
                            cards.Remove(grandchild.GetComponent<Grabbable>().cardNumber);
                        }
                    }
                }
            }
        }

    }
}
