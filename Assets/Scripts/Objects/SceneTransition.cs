using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad; // 이동할 씬 이름
    // 돌아올 때 대비용 플레이어 위치 저장
    public Vector2 playerPosition; 
    public VectorValue playerStorage;
    // FadeOut-FadeIn, 그 시간 코루틴 처리를 위함
    // awake나 start와 같은 처리를 할 때 걸리는 시간을 위해
    // fadeWait로 그 시간을 확보하고
    // FadeIn-Out 효과로 갑자기 빡! 하고 나타나는 것이 아닌
    // 자연스러운 씬 전환 처리를 할 수 있음
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private void Awake()
    {
        if (fadeInPanel != null) // 일종의 Panel에 대한 싱글톤 처리
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    // Player가 그 위치로 왔을 시 플레이어의 현 위치를 저장하고
    // 다른 씬을 로드
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo()); // Fade관련 코루틴에서 실질적으로 씬 불러옴
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Fade-out 처리
    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null) // 하나만 있게 하기 위함, 일종의 싱글톤 처리
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait); // 시간 확보

        // 씬 로드 (싱크를 맞추기 위함)
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

}
