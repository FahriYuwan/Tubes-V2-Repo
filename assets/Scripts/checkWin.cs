using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWin : MonoBehaviour
{
    bool win = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Flag")
        {
            win = true;
            Debug.Log("Win");
        }
    }
    
    public bool getWin()
    {
        return win;
    }
}
