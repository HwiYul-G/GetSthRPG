using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // menu �г� ó��
    // ������ PausPanel�� �ѹ��� ���Ƽ� �ۼ��߾���ϴ� �ڵ�
    public GameObject menuPanel;

    void Start()
    {
        menuPanel.SetActive(false);
    }

    private void Update()
    {
        // ESC Ű Ŭ���� menuPanel Ȱ��ȭ �� ��Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            menuPanel.SetActive(false);
        }
    }
    // menu �г���exit ��ư Ŭ���� ����Ǵ� �Լ�
    public void ExitClicked()
    {
        Application.Quit();
    }

}
