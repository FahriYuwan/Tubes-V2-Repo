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
    int cardIndex = 0;

    float elapsedTime = 0f;
    float desiredTime = 1f;
    float speed = 0.02f;

    bool sw = false;
    bool setBeforeBoundary = false;
    bool boundary = false;

    Vector3 initPos;
    Quaternion initRot;

    Vector3 startPos;
    Vector3 endPos;

    Quaternion startRot;
    Quaternion endRot;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        initPos = transform.position;
        initRot = transform.rotation;

        startPos = transform.position;
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (sw)
        {
            if (cardManager.cards.Count == 0)
            {
                sw = false;
                return;
            }

            int card = cardManager.cards[cardIndex];
            elapsedTime += Time.deltaTime * speed;
            float perc = elapsedTime / desiredTime;

            if (card == 1 && !boundary)
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

                if (setBeforeBoundary)
                {
                    boundary = true;
                }

                if (cardIndex >= cardManager.cards.Count)
                {
                    Reset();
                }
            }
        }
    }

    public void Execute()
    {
        sw = true;
    }

    public void Reset()
    {
        transform.position = initPos;
        transform.rotation = initRot;
        startPos = initPos;
        currentDirection = 0;
        cardIndex = 0;
        elapsedTime = 0f;
        sw = false;
        setBeforeBoundary = false;
        boundary = false;
    }

    public void ResetButton() {
        Reset();
        // delete all cards gameobject except the first one, but still delete the child of it
        foreach (Transform child in cardManager.transform)
        {
            if (child.GetSiblingIndex() != 0)
            {
                Destroy(child.gameObject);
            } else {
                Destroy(child.GetChild(0).gameObject);
            }
        }
    }

    void cycleAxis(int turn) {
        if (turn == 0) {
            currentDirection = (currentDirection + 1) % directions.Length;
        } else {
            currentDirection = (currentDirection - 1 + directions.Length) % directions.Length;
        }
        Debug.Log("Current direction: " + currentDirection);
    }

    void OnTriggerStay(Collider other)
    {
        // check if other object parent is tagged 
        if (other.transform.parent.tag == "Bounds")
        {
            Debug.Log("Boundary entered");
            setBeforeBoundary = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // check if other object parent is tagged 
        if (other.transform.parent.tag == "Bounds")
        {
            Debug.Log("Boundary exited");
            boundary = false;
            setBeforeBoundary = false;
        }
    }
}
