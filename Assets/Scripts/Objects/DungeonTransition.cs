using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonTransition : MonoBehaviour
{
    public string sceneToLoad; // Loading�� �� �̸��� ������Ʈ â���� ����
    // room�� ��� ���Դ� ������ ���� ����ؼ� �� ��ġ�� ������
    public Vector2 playerPosition; 
    public VectorValue playerStorage;
    // �� ��ȯ�� �ڿ��������� ���� fadeIn, FadeOut ó�� Panel
    // �� �� �ε�� �ʿ��� �ð��� ���� ó��
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;
    // GameManager�� ������ ���� chk �ϹǷ� �ʿ�
    public GameManager theGM;
    public GameObject chalicesLackPanel;


    // �ʱ�ȭ
    private void Awake()
    {
        if (fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
        //FindObjectOfType�� �޸𸮿� ���� ���� �ʴٰ� �ؼ� �����ʿ�
        theGM = FindObjectOfType<GameManager>();
        chalicesLackPanel.SetActive(false); //�⺻������ �Ⱥ��̰�
    }

    // BoxCollider 2D �� ������ �� ��ȯ Ȥ�� ���谳�� ������ ���� �ȳ��ϰ� �ϴ� �Լ�
    public void OnTriggerEnter2D(Collider2D other)
    {
        // ���谳���� ���� üũ�� GameManager�� cahlices ������ ���ؼ� �� (public ó��)
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
    // �־����� ���谳�� ���� Panel ���� ����
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chalicesLackPanel.SetActive(false);
        }        
    }
    // Fade Out�� Fade In ȿ���� ���� �ڷ�ƾ �Լ�. 
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
