using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkWin : MonoBehaviour
{
    bool win = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Flag")
        {
            win = true;
            UnlockNextLevel();
            Debug.Log("Win");
        }
    }
    
    public bool getWin()
    {
        return win;
    }

    void UnlockNextLevel()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        if (levelReached == SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("levelReached", levelReached + 1);
            PlayerPrefs.Save();
        }
    }
}
