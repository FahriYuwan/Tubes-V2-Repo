using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public GameObject MainMenu, pilihLantai, caraBermain, Credits;
    bool pilihLantaiOn = false, caraBermainOn = false, creditsOn = false;
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
        MainMenu.SetActive(true);
        pilihLantai.SetActive(false);
        caraBermain.SetActive(false);
        Credits.SetActive(false);

        // Ensure ClickSound does not loop
        if (ClickSound != null)
        {
            ClickSound.loop = false;
        }
    }

    public void PlayButtonPressed()
    {
        PlayClickSound();
        // Toggle between MainMenu and pilihLantai
        if (pilihLantaiOn)
        {
            ShowMainMenu();
        }
        else
        {
            ShowPilihLantai();
        }
    }

    public void ReturnToMainMenu()
    {
        PlayClickSound();
        ShowMainMenu();
    }

    public void HowToPlayButtonPressed()
    {
        PlayClickSound();
        // Toggle between MainMenu and caraBermain
        if (caraBermainOn)
        {
            ShowMainMenu();
        }
        else
        {
            ShowCaraBermain();
        }
    }

    public void CreditsButtonPressed()
    {
        PlayClickSound();
        // Toggle between MainMenu and Credits
        if (creditsOn)
        {
            ShowMainMenu();
        }
        else
        {
            ShowCredits();
        }
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
        pilihLantaiOn = false;
        caraBermainOn = false;
        creditsOn = false;
    }

    private void ShowPilihLantai()
    {
        MainMenu.SetActive(false);
        pilihLantai.SetActive(true);
        caraBermain.SetActive(false);
        Credits.SetActive(false);
        pilihLantaiOn = true;
        caraBermainOn = false;
        creditsOn = false;
    }

    private void ShowCaraBermain()
    {
        MainMenu.SetActive(false);
        pilihLantai.SetActive(false);
        caraBermain.SetActive(true);
        Credits.SetActive(false);
        pilihLantaiOn = false;
        caraBermainOn = true;
        creditsOn = false;
    }

    private void ShowCredits()
    {
        MainMenu.SetActive(false);
        pilihLantai.SetActive(false);
        caraBermain.SetActive(false);
        Credits.SetActive(true);
        pilihLantaiOn = false;
        caraBermainOn = false;
        creditsOn = true;
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
