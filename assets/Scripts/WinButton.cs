using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButton : MonoBehaviour
{
    [SerializeField] Animator transition;

    public void Selanjutnya()
    {
        Debug.Log("Level selanjutnya");
        // SceneManager.LoadScene("Level2");
    }

    public void Restart()
    {
        Debug.Log("Restart Level");
        Time.timeScale = 1f;
        StartCoroutine(AnimationLoad(SceneManager.GetActiveScene().name));
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
        // SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Debug.Log("Exit...");
        Application.Quit();
    }

    IEnumerator AnimationLoad(string sceneName)
    {
        Debug.Log("Animation Load");
        // Play animation
        transition.SetTrigger("Start");
        Debug.Log("Animation Played");
        // Wait
        yield return new WaitForSeconds(1f); // Change depending on transistion time
        Debug.Log("Waited");
        //Load Scene
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene Loaded");
    }
}
