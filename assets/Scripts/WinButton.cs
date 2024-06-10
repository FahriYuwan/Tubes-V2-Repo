using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButton : MonoBehaviour
{
    [SerializeField] Animator transition;

    public void Selanjutnya()
    {
        // get current scene index, add 1, load next scene
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        // but if the this scene is "Level3", load "MainMenu"
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void Restart()
    {
        Debug.Log("Restart Level");
        Time.timeScale = 1f;
        StartCoroutine(AnimationLoad(SceneManager.GetActiveScene().name));
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Main Menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
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
