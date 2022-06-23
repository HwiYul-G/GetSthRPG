using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{
    public GameObject gameoverPanel;
    public GameObject player;

    public string SceneName;

    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    // ���� ���� �� �÷��̾��� hp�� �̿��ؼ� gameOver�̶� bool ������
    //�����ؼ� �Ǵ���
    // ���� ���� ���ο� ���� gameOverPanel Ȱ��ȭ �� ��Ȱ��ȭ
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().gameOver)
        {
            gameoverPanel.SetActive(true);
        }
        else
        {
            gameoverPanel.SetActive(false);
        }
    }
    // restart ��ư Ŭ���� ���� ���Ӿ�(����)
    // ���� �ٽ� �����ϰ� ��
    public void restartBtnClick()
    {
        SceneManager.LoadScene(SceneName);
        player.GetComponent<PlayerMovement>().currentHealth.RuntimeValue =
    player.GetComponent<PlayerMovement>().currentHealth.initialValue;
    }
}
