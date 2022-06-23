using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal context; //palyer�� �޷��ִ� ���ؽ�Ʈ Ŭ�� setAcitveó��
    public bool playerInRange; // player���� ���� üũ

    // ����� ���� ���ؽ�Ʈ Ŭ�� ���̵���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = true;
        }
    }
    // ������ �������� ���� �� ���� ���ؽ�Ʈ ���ֱ�
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
