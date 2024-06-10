using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PilihLantai : MonoBehaviour
{
    public AudioSource ClickSound;
    public float fadeDuration = 1.0f;
    public Button[] levelButtons;

    private void Awake()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        Debug.Log("levelReached: " + levelReached);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        PlayerPrefs.SetInt("ReachedIndex", 1);
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs reset: levelReached set to 1, ReachedIndex set to 1");
        Awake();
    }
    private void PlayClickSound()
    {
        if (ClickSound != null)
        {
            ClickSound.Play();
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        PlayClickSound();
        if (levelId == 1)
        {
            StartCoroutine(FadeOutAndLoadScene("Cutscene"));
        }
        else
        {
            StartCoroutine(FadeOutAndLoadScene(levelName));
        }
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        if (ClickSound != null)
        {
            float startVolume = ClickSound.volume;

            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                ClickSound.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
                yield return null;
            }

            ClickSound.volume = 0;
            ClickSound.Stop();
        }

        SceneManager.LoadScene(sceneName);
    }
}
