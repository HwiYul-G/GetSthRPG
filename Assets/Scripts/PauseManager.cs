using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused;
    //public GameObject pausePanel;
    public GameObject inventoryPanel;
    //public bool usingPausePanel;
    //public string mainMenu;
    public string itemInventory;
    public bool usingInventoryPanel;

    void Start()
    {
        isPaused = false;
        //pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        //usingPausePanel = false;
        usingInventoryPanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangePause();
            ShowInventoryPanel();
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
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }
}
