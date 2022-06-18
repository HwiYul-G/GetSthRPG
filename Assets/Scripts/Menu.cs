using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;

    void Start()
    {
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            menuPanel.SetActive(false);
        }
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

}
