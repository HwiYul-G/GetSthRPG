using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // menu 패널 처리
    // 원래는 PausPanel에 한번에 몰아서 작성했어야하는 코드
    public GameObject menuPanel;

    void Start()
    {
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        // ESC 키 클릭시 menuPanel 활성화 및 비활성화
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            menuPanel.SetActive(false);
        }
    }
    // menu 패널의exit 버튼 클릭시 실행되는 함수
    public void ExitClicked()
    {
        Application.Quit();
    }

}
