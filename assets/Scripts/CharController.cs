using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Animator animator;
<<<<<<< HEAD
=======
    public CardManager cardManager;
    // four directions
    string[] directions = {"front", "right", "back", "left"};
    int currentDirection = 0;
    int cardIndex = 0;

    float elapsedTime = 0f;
    float desiredTime = 1f;
    float speed = 0.02f;

    bool sw = false;

    Vector3 startPos;
    Vector3 endPos;

    Quaternion startRot;
    Quaternion endRot;
>>>>>>> e87d200794e2447c436b855a305d326d455656c6
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
<<<<<<< HEAD
=======
        startPos = transform.position;
        startRot = transform.rotation;
>>>>>>> e87d200794e2447c436b855a305d326d455656c6
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
=======
        if (sw)
        {
            int card = cardManager.cards[cardIndex];
            elapsedTime += Time.deltaTime * speed;
            float perc = elapsedTime / desiredTime;

            if (card == 1)
            {
                if (directions[currentDirection] == "front")
                {
                    // transform.position += new Vector3(0, 0, -1);
                    // use lerp
                    endPos = startPos + new Vector3(0, 0, -1);
                    transform.position = Vector3.Lerp(transform.position, endPos, perc);
                }
                else if (directions[currentDirection] == "right")
                {
                    // transform.position += new Vector3(-1, 0, 0);
                    endPos = startPos + new Vector3(-1, 0, 0);
                    transform.position = Vector3.Lerp(transform.position, endPos, perc);
                }
                else if (directions[currentDirection] == "back")
                {
                    // transform.position += new Vector3(0, 0, 1);
                    endPos = startPos + new Vector3(0, 0, 1);
                    transform.position = Vector3.Lerp(transform.position, endPos, perc);
                }
                else if (directions[currentDirection] == "left")
                {
                    // transform.position += new Vector3(1, 0, 0);
                    endPos = startPos + new Vector3(1, 0, 0);
                    transform.position = Vector3.Lerp(transform.position, endPos, perc);
                }
            }
            else if (card == 2)
            {
                // add 90 to y rotation
                // transform.Rotate(0, 90, 0);
                // use lerp
                endRot = startRot * Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, endRot, perc);
                if (elapsedTime >= speed)
                {
                    cycleAxis(0);
                }
            }
            else if (card == 3)
            {
                // transform.Rotate(0, -90, 0);
                // use lerp
                endRot = startRot * Quaternion.Euler(0, -90, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, endRot, perc);
                if (elapsedTime >= speed)
                {
                    cycleAxis(1);
                }
            }
            else if (card == 4)
            {
                // Debug.Log("Attack");
                Debug.Log("Attack");
            }
            if (elapsedTime >= speed)
            {
                elapsedTime = 0f;
                cardIndex++;
                startPos = transform.position;
                startRot = transform.rotation;
                if (cardIndex >= cardManager.cards.Count)
                {
                    sw = false;
                    cardIndex = 0;
                }
            }
        }
    }

    public void cardIterator()
    {
        cardIndex++;
    }

    public void Execute()
    {
        // StartCoroutine(ShowCards());
        sw = true;
    }

    void cycleAxis(int turn) {
        if (turn == 0) {
            currentDirection++;
        } else {
            currentDirection--;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
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
>>>>>>> e87d200794e2447c436b855a305d326d455656c6
        }
    }
}
