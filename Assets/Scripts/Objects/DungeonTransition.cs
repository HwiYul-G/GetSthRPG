using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonTransition : MonoBehaviour
{
    public string sceneToLoad; // Loading할 씬 이름을 컴포넌트 창에서 받음
    // room의 경우 들어왔다 나가는 것을 고려해서 현 위치를 저장함
    public Vector2 playerPosition; 
    public VectorValue playerStorage;
    // 씬 전환시 자연스러움을 인해 fadeIn, FadeOut 처리 Panel
    // 및 씬 로드시 필요한 시간을 위한 처리
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;
    // GameManager가 성배의 수를 chk 하므로 필요
    public GameManager theGM;
    public GameObject chalicesLackPanel;


    // 초기화
    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
        //FindObjectOfType는 메모리에 별로 좋지 않다고 해서 수정필요
        theGM = FindObjectOfType<GameManager>();
        chalicesLackPanel.SetActive(false); //기본적으로 안보이게
    }

    // BoxCollider 2D 에 들어오면 씬 전환 혹은 성배개수 부족에 대해 안내하게 하는 함수
    public void OnTriggerEnter2D(Collider2D other)
    {
        // 성배개수에 대한 체크는 GameManager의 cahlices 변수를 통해서 함 (public 처리)
        if (other.CompareTag("Player") && !other.isTrigger && theGM.chalices == 6)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo());
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (other.CompareTag("Player") && !other.isTrigger &&theGM.chalices < 6) 
        {
            chalicesLackPanel.SetActive(true);
        }
    }
    // 멀어지면 성배개수 부족 Panel 끄기 위함
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chalicesLackPanel.SetActive(false);
        }        
    }
    // Fade Out과 Fade In 효과를 위한 코루틴 함수. 
    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
