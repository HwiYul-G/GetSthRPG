using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    // AudioManager를 이용해 click_sound 효과 내기
    private AudioManager theAudio;
    public string click_sound;
    // 메인도 씬 전환시 Fade 효과를 내야 자연스럽고
    // 로딩되는 것의 코루틴 처리도 할 수 있음
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;
    // 게임 키 동작에 대한 설명을 위한 패널
    public GameObject explainPanel;

    private void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        explainPanel.SetActive(false);
    }
    // 게임 시작시 첫 시작 되는 씬을 부름
    public void PlayGame()
    {
        StartCoroutine(PlayGameCoroutine());
    }
    // 코루틴 처리
    IEnumerator PlayGameCoroutine()
    {
        theAudio.Play(click_sound);
        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene("StartScene");
        StartCoroutine(FadeCo());
    }
    // 설명 버튼 클릭시 exPlainPanel 활성화 및 비활성화
    public void explainButtonClicked()
    {
        explainPanel.SetActive(true);
    }
    public void explainCloseClicked()
    {
        explainPanel.SetActive(false);
    }
    // 게임 종료
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
