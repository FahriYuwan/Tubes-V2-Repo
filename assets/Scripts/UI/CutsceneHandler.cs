using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneHandler : MonoBehaviour
{
    public GameObject Cutscene1, Cutscene2, Cutscene3, Cutscene4;
    public AudioSource ClickSound, CutsceneMusic;
    public float fadeDuration = 1.0f;

    void Start()
    {
        var audioControl = FindObjectOfType<AudioControl>();
        if (audioControl != null)
        {
            // Memutar musik bgm_cutscene secara looping
            audioControl.PlayMusic("bgm_cutscene");
        }
        else
        {
            Debug.LogError("AudioControl not found in the scene!");
        }
        Cutscene1.SetActive(true);
        Cutscene2.SetActive(false);
        Cutscene3.SetActive(false);
        Cutscene4.SetActive(false);

        // Ensure ClickSound does not loop
        if (ClickSound != null)
        {
            ClickSound.loop = false;
        }
    }

    public void NextButtonPressed()
    {
        PlayClickSound();
        // Toggle between Cutscene1 and Cutscene2
        if (Cutscene1.activeSelf)
        {
            ShowCutscene2();
        }
        else if (Cutscene2.activeSelf)
        {
            ShowCutscene3();
        }
        else if (Cutscene3.activeSelf)
        {
            ShowCutscene4();
        }
        else if (Cutscene4.activeSelf)
        {
            // Start fade out and load next scene
            StartCoroutine(FadeOutAndLoadScene("Level1"));
        }
    }

    public void BackButtonPressed()
    {
        PlayClickSound();
        // Debug.Log("BackButtonPressed");
        // Toggle between Cutscene2 and Cutscene1
        if (Cutscene2.activeSelf)
        {
            ShowCutscene1();
        }
        else if (Cutscene3.activeSelf)
        {
            ShowCutscene2();
        }
        else if (Cutscene4.activeSelf)
        {
            ShowCutscene3();
        }
    }

    public void SkipButtonPressed()
    {
        PlayClickSound();
        // Start fade out and load next scene
        StartCoroutine(FadeOutAndLoadScene("Level1"));
    }

    public void ShowCutscene1()
    {
        Cutscene1.SetActive(true);
        Cutscene2.SetActive(false);
        Cutscene3.SetActive(false);
        Cutscene4.SetActive(false);
    }
    public void ShowCutscene2()
    {
        Cutscene1.SetActive(false);
        Cutscene2.SetActive(true);
        Cutscene3.SetActive(false);
        Cutscene4.SetActive(false);
    }
    public void ShowCutscene3()
    {
        Cutscene1.SetActive(false);
        Cutscene2.SetActive(false);
        Cutscene3.SetActive(true);
        Cutscene4.SetActive(false);
    }
    public void ShowCutscene4()
    {
        Cutscene1.SetActive(false);
        Cutscene2.SetActive(false);
        Cutscene3.SetActive(false);
        Cutscene4.SetActive(true);
    }
    public void PlayClickSound()
    {
        if (ClickSound != null)
        {
            // Debug.Log("ClickSound played");
            ClickSound.Play();
        }
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        if (CutsceneMusic != null)
        {
            float startVolume = CutsceneMusic.volume;

            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                CutsceneMusic.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
                yield return null;
            }

            CutsceneMusic.volume = 0;
            CutsceneMusic.Stop();
        }

        SceneManager.LoadScene(sceneName);
    }
}
