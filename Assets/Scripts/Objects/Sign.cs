using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    // �̹��ִ� ���̾˷α� Panel�� �α�
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    void Update()
    {
        // Sign���� space bar ������, �پ�α� Ȱ��ȭ
        // Sign�� ��ϵ� string ������ �� �������� ��
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
    // �־����� ��Ȱ��ȭ
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }

}
