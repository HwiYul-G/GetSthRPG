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

    // 게임 오버 는 플레이어의 hp를 이용해서 gameOver이란 bool 변수를
    //변경해서 판단함
    // 게임 오버 여부에 따라서 gameOverPanel 활성화 및 비활성화
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
    // restart 버튼 클릭시 메인 게임씬(성안)
    // 부터 다시 시작하게 함
    public void restartBtnClick()
    {
        SceneManager.LoadScene(SceneName);
        player.GetComponent<PlayerMovement>().currentHealth.RuntimeValue =
    player.GetComponent<PlayerMovement>().currentHealth.initialValue;
    }
}
