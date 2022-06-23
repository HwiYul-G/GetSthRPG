using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public string sceneToLoad; // �̵��� �� �̸�
    // ���ƿ� �� ���� �÷��̾� ��ġ ����
    public Vector2 playerPosition; 
    public VectorValue playerStorage;
    // FadeOut-FadeIn, �� �ð� �ڷ�ƾ ó���� ����
    // awake�� start�� ���� ó���� �� �� �ɸ��� �ð��� ����
    // fadeWait�� �� �ð��� Ȯ���ϰ�
    // FadeIn-Out ȿ���� ���ڱ� ��! �ϰ� ��Ÿ���� ���� �ƴ�
    // �ڿ������� �� ��ȯ ó���� �� �� ����
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private void Awake()
    {
        if (fadeInPanel != null) // ������ Panel�� ���� �̱��� ó��
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }

    // Player�� �� ��ġ�� ���� �� �÷��̾��� �� ��ġ�� �����ϰ�
    // �ٸ� ���� �ε�
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            StartCoroutine(FadeCo()); // Fade���� �ڷ�ƾ���� ���������� �� �ҷ���
            //SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Fade-out ó��
    public IEnumerator FadeCo()
    {
        if (fadeOutPanel != null) // �ϳ��� �ְ� �ϱ� ����, ������ �̱��� ó��
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(fadeWait); // �ð� Ȯ��

        // �� �ε� (��ũ�� ���߱� ����)
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

}
