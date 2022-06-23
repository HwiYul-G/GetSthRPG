using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Unity에 마치 기본으로 있는 것처럼
// NewItem이란 것 하위로 Inventory/Items를 넣어서
// 구현을 신경 쓰지 않고 할 수 있게 함.
[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Items")]

public class InventoryItem : ScriptableObject
{
    // 아이템 관련 정보
    public string itemName; // 이름
    public string itemDescription; // 설명
    public Sprite itemImage; // 이미지
    public int numberHeld; // 개수
    public bool usable; // 사용가능한 아이템인지
    public bool unique; // 게임 상 유일한 건지
    public UnityEvent thisEvent; // 아이템 사용 이벤트 처리

    // 현재 게임에서는 사용가능한 아이템은 없음
    public void Use()
    {
        thisEvent.Invoke(); // 사용시 이벤트 효과 시작
    }

    // 사용시  아이템 개수 감소
    public void DecreaseAmount(int amountToDecrease)
    {
        numberHeld -= amountToDecrease;
        if(numberHeld < 0)
        {
            numberHeld = 0;
        }
    }

}
