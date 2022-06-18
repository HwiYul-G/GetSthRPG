using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int chalices = 0;
    //private FadeManager theFade;

    private void OnEnable()
    {
        //theFade = FindObjectOfType<FadeManager>();
    }


    public void LoadStart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadWaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        //theFade = FindObjectOfType<FadeManager>();

        //theFade.FadeIn();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
