using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
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

    // Update is called once per frame
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

    public void ExitGame()
    {
        Application.Quit();
    }
}
