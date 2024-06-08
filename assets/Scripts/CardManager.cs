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

    IEnumerator shiftCards(int index)
    {
        yield return new WaitForSeconds(0.1f);
        // shift all cards from index to the right
        for (int i = index; i < transform.childCount; i++)
        {
            // get the current i card
            Transform card = transform.GetChild(i);
            // change its sibling index to i+1
            card.SetSiblingIndex(i + 1);
        }
    }
}
