using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject MainMenu, pilihLantai, caraBermain, Credits;
    public AudioSource ClickSound, MainMenuMusic;
    public float fadeDuration = 1.0f;

    void Start()
    {
        var audioControl = FindObjectOfType<AudioControl>();
        if (audioControl != null)
        {
            // Memutar musik MainMenuMusic secara looping
            audioControl.PlayMusic("MainMenuMusic");
        }
        else
        {
            Debug.LogError("AudioControl not found in the scene!");
        }
        ShowMainMenu();

        // Ensure ClickSound does not loop
        if (ClickSound != null)
        {
            ClickSound.loop = false;
        }

        // Check if it's the first time the game is run
        if (!PlayerPrefs.HasKey("isInitialized"))
        {
            // Initialize levelReached and ReachedIndex
            PlayerPrefs.SetInt("levelReached", 1); // Start at level 1 by default
            PlayerPrefs.SetInt("ReachedIndex", 1); // Start at index 1 by default
            
            // Set an initialization flag
            PlayerPrefs.SetInt("isInitialized", 1);
            PlayerPrefs.Save();

            Debug.Log("PlayerPrefs initialized: levelReached set to 1, ReachedIndex set to 1");
        }
        else
        {
            Debug.Log("PlayerPrefs already initialized");
        }

        Debug.Log("ReachedIndex: " + PlayerPrefs.GetInt("ReachedIndex"));
        Debug.Log("levelReached: " + PlayerPrefs.GetInt("levelReached"));
    }
    
    public void PlayButtonPressed()
    {
        PlayClickSound();
        ShowPilihLantai();
    }

    public void ReturnToMainMenu()
    {
        PlayClickSound();
        ShowMainMenu();
    }

    public void HowToPlayButtonPressed()
    {
        PlayClickSound();
        ShowCaraBermain();
    }

    public void CreditsButtonPressed()
    {
        PlayClickSound();
        ShowCredits();
    }

    public void QuitGame()
    {
        PlayClickSound();
        StartCoroutine(FadeOutAndQuitGame());
    }

    private void ShowMainMenu()
    {
        MainMenu.SetActive(true);
        pilihLantai.SetActive(false);
        caraBermain.SetActive(false);
        Credits.SetActive(false);
    }

    private void ShowPilihLantai()
    {
        MainMenu.SetActive(false);
        pilihLantai.SetActive(true);
        caraBermain.SetActive(false);
        Credits.SetActive(false);
    }

    private void ShowCaraBermain()
    {
        MainMenu.SetActive(false);
        pilihLantai.SetActive(false);
        caraBermain.SetActive(true);
        Credits.SetActive(false);
    }

    private void ShowCredits()
    {
        MainMenu.SetActive(false);
        pilihLantai.SetActive(false);
        caraBermain.SetActive(false);
        Credits.SetActive(true);
    }

    private void PlayClickSound()
    {
        if (ClickSound != null)
        {
            ClickSound.Play();
        }
    }

    private IEnumerator FadeOutAndQuitGame()
    {
        if (MainMenuMusic != null)
        {
            float startVolume = MainMenuMusic.volume;

            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                MainMenuMusic.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
                yield return null;
            }

            MainMenuMusic.volume = 0;
            MainMenuMusic.Stop();
        }

        Application.Quit();
    }
}
