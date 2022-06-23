using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    //Inventory 창 키거나 esc 버튼으로 menu창 킬때 
    // 그 해당 패널이 setActive(true) 되게 하고
    // 시간이 멈추게 하기 위한 처리
    private bool isPaused; // 시간 멈춤에 대한 변수

    //public GameObject pausePanel;
    public GameObject inventoryPanel;
    //public bool usingPausePanel;
    //public string mainMenu;
    //public string itemInventory;
    public bool usingInventoryPanel;

    public GameObject menuPanel;
    public bool usingMenuPanel;
    
    void Start()
    {
        isPaused = false;
        //pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        //usingPausePanel = false;
        usingInventoryPanel = false;

        menuPanel.SetActive(false);
        usingMenuPanel = false;
        
    }

    // Z키 누르면 시간이 멈추고 인벤토리 창이 켜짐
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangePause();
            ShowInventoryPanel();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePause();
            ShowMenuPanel();
        }
    }
    // 게임 전체의 시간을 멈추고 풀고 하게 하는 함수
    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            //pausePanel.SetActive(true);
            Time.timeScale = 0f;
            //usingPausePanel = true;
        }
        else
        {
            //pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    // 인벤토리 페널이 보이게 하는 함수
    public void ShowInventoryPanel()
    {
        usingInventoryPanel = !usingInventoryPanel;
        if (usingInventoryPanel)
        {
            inventoryPanel.SetActive(true);
            usingInventoryPanel = true;
        }
        else
        {
            inventoryPanel.SetActive(false);
            //usingInventoryPanel = false;
        }
    }

    // 메뉴 패널이 보이게 하는 함수
    public void ShowMenuPanel()
    {
        usingMenuPanel = !usingMenuPanel;
        if (usingMenuPanel)
        {
            menuPanel.SetActive(true);
            usingMenuPanel = true;
        }
        else
        {
            menuPanel.SetActive(false);
        }
    }
    // 메뉴 패널에서 exit 버튼 누르면 나가게 하는 함수
    public void ExitGame()
    {
        Application.Quit();
    }
}
