using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private AudioManager theAudio;

    public string click_sound;

    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    public GameObject explainPanel;

    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        explainPanel.SetActive(false);
    }

    public void PlayGame()
    {
        StartCoroutine(PlayGameCoroutine());
    }

    IEnumerator PlayGameCoroutine()
    {
        theAudio.Play(click_sound);
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene("StartScene");
        StartCoroutine(FadeCo());
    }

    public void explainButtonClicked()
    {
        explainPanel.SetActive(true);
    }
    public void explainCloseClicked()
    {
        explainPanel.SetActive(false);
    }

    public void ExitGame()
    {
        theAudio.Play(click_sound);
        Application.Quit();
    }

    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("StartScene");
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
