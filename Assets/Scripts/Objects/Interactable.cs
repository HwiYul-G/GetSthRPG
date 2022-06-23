using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signal context; //palyer에 달려있는 컨텍스트 클루 setAcitve처리
    public bool playerInRange; // player와의 범위 체크

    // 가까워 질때 컨텍스트 클루 보이도록
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = true;
        }
    }
    // 나갈때 아이템을 받을 수 없고 컨텍스트 없애기
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
