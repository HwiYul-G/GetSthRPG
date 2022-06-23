using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    //Inventory â Ű�ų� esc ��ư���� menuâ ų�� 
    // �� �ش� �г��� setActive(true) �ǰ� �ϰ�
    // �ð��� ���߰� �ϱ� ���� ó��
    private bool isPaused; // �ð� ���㿡 ���� ����

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

    // ZŰ ������ �ð��� ���߰� �κ��丮 â�� ����
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
    // ���� ��ü�� �ð��� ���߰� Ǯ�� �ϰ� �ϴ� �Լ�
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
    // �κ��丮 ����� ���̰� �ϴ� �Լ�
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

    // �޴� �г��� ���̰� �ϴ� �Լ�
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
    // �޴� �гο��� exit ��ư ������ ������ �ϴ� �Լ�
    public void ExitGame()
    {
        Application.Quit();
    }
}
