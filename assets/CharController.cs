using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Animator animator;
    public CardManager cardManager;
    // four directions
    string[] directions = {"front", "right", "back", "left"};
    int currentDirection = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get all the 
    }

    public void Execute()
    {
        StartCoroutine(ShowCards());
        // // check the list of cards
        // foreach (int card in cardManager.cards)
        // {
        //     if (card == 1)
        //     {
        //         transform.position += new Vector3(0, 0, -1);
        //     }
        //     else if (card == 2)
        //     {
        //         // add 90 to y rotation
        //         transform.Rotate(0, 90, 0);
        //     }
        //     else if (card == 3)
        //     {
        //         transform.Rotate(0, -90, 0);
        //     }
        //     else if (card == 4)
        //     {
        //         // Debug.Log("Attack");
        //         Debug.Log("Attack");
        //     }
        //     // wait for 1 second
        //     StartCoroutine(Wait());
        // }
    }

    void cycleAxis(int turn) {
        if (turn == 0) {
            currentDirection++;
        } else {
            currentDirection--;
        }
    }

    IEnumerator ShowCards()
    {
        foreach (var card in cardManager.cards)
        {
            if (card == 1)
            {
                // transform.position += new Vector3(lX, lY, lZ);
                if (directions[currentDirection] == "front")
                {
                    transform.position += new Vector3(0, 0, -1);
                }
                else if (directions[currentDirection] == "right")
                {
                    transform.position += new Vector3(-1, 0, 0);
                }
                else if (directions[currentDirection] == "back")
                {
                    transform.position += new Vector3(0, 0, 1);
                }
                else if (directions[currentDirection] == "left")
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
            else if (card == 2)
            {
                // add 90 to y rotation
                transform.Rotate(0, 90, 0);
                cycleAxis(0);
            }
            else if (card == 3)
            {
                transform.Rotate(0, -90, 0);
                cycleAxis(1);
            }
            else if (card == 4)
            {
                // Debug.Log("Attack");
                Debug.Log("Attack");
            }
            yield return new WaitForSeconds(0.5f); // wait for half a second
        }
    }
}
