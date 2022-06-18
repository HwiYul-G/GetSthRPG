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

    // Update is called once per frame
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

    public void restartBtnClick()
    {
        SceneManager.LoadScene(SceneName);
        player.GetComponent<PlayerMovement>().currentHealth.RuntimeValue =
    player.GetComponent<PlayerMovement>().currentHealth.initialValue;
    }
}
