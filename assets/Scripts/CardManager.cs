using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // list of cards
    public List<int> cards;
    public bool shift = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(checkCards());
    }

    IEnumerator checkCards()
    {
        yield return new WaitForSeconds(0.1f);
        cards.Clear();
        foreach (Transform child in transform)
        {
            foreach (Transform grandchild in child)
            {
                if (grandchild.GetComponent<Grabbable>() != null)
                {
                    cards.Add(grandchild.GetComponent<Grabbable>().type);
                }
            }
        }
    }

    public void shiftCards(int index, int droppedIndex)
    {
        // how do I get the index of the dropped object?
        if (droppedIndex == -1)
        {
            shiftRight(index);
            return;
        }
        else if (index == droppedIndex)
        {
            Debug.Log("Same index");
            return;
        }
        else if (index < droppedIndex)
        {
            Debug.Log("Index is less than dropped index");
            shiftRight(index);
        }
        else if (index > droppedIndex)
        {
            Debug.Log("Index is greater than dropped index");
            shiftLeft(index);
        }
    }

    void shiftRight(int index) {
        // shift all cards from index to the right
        for (int i = index; i < cards.Count; i++)
        {
            // if only one child, continue
            if (transform.GetChild(i).childCount == 1 && i != index)
            {
                Debug.Log("No child found");
                continue;
            }
            // get the current i card
            Transform cardSlot = transform.GetChild(i);
            // get the card in the card slot
            Transform card = cardSlot.GetChild(0);
            // set the parent of card to be the next card slot
            card.GetComponent<Grabbable>().originalParent = transform.GetChild(i + 1);
            card.SetParent(transform.GetChild(i + 1));
        }
    }

    void shiftLeft(int index) {
        // shift all cards from index to the left
        for (int i = index; i >= 0; i--)
        {
            // if only one child, continue
            if (transform.GetChild(i).childCount == 1 && i != index)
            {
                Debug.Log("No child found");
                continue;
            }
            // get the current i card
            Transform cardSlot = transform.GetChild(i);
            // get the card in the card slot
            Transform card = cardSlot.GetChild(0);
            // set the parent of card to be the next card slot
            card.GetComponent<Grabbable>().originalParent = transform.GetChild(i - 1);
            card.SetParent(transform.GetChild(i - 1));
        }
    }
}
