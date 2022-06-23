using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 유니티에 기본으로 있는 것처럼 New Inventory라는 상위 폴더 내로 하위로 menu를 넣음
[CreateAssetMenu(fileName ="New Inventory", menuName = "Inventory/Palyer Inventory") ]

// ScriptableObject는 유니티에서 제공하는 대량 데이터 저장을 위한 데이터 통(?)이다.
// 사본 생성을 방지해 메모리를 줄일 수 있다.
// 메모리에 스크럽터블 오브젝트의 데이터 사본을 저장해 이를 반복해서 참조하게 되므로
// 메모리를 줄일 수 잇게 되는 것이다.
public class PlayerInventory : ScriptableObject
{
    // List로 실제로 플레이어가 가진 인벤토리의 아이템들을 처리함
    public List<InventoryItem> myInventory = new List<InventoryItem>();
}
