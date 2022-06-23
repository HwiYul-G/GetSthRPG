using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    // 이미있는 다이알로그 Panel을 두기
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    void Update()
    {
        // Sign에서 space bar 누르면, 다얄로그 활성화
        // Sign에 등록된 string 변수를 그 내용으로 함
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    // 멀어지면 비활성화
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

}
