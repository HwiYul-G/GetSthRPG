using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // Header : 유니티 컴포넌트에 가따되면 설명이 뜸
    [Header("UI stuff to change")]
    // private로 외부에서 사용하지 못하게 막고
    // serialziedField로 직렬화 처리(public처럼 컴포넌트에서 보이게)
    [SerializeField] private Text itemNumberText;
    [SerializeField] private Image itemImage;

    // Header로 설명
    [Header("Variables from the item")]
    public InventoryItem thisItem; // 현재는 슬롯이므로 아이템 처리
    public InventoryManager thisManager;  //메니저로 대부분 처리

    // 슬롯에 새로운 아이템이 추가 될 때, 업데이트를 위한 처리
    public void Setup(InventoryItem newItem, InventoryManager newManager)
    {
        thisItem = newItem;
        thisManager = newManager;
        if(thisItem)
        {
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = "" +  thisItem.numberHeld;
        }

    }
     // 클릭시 아이템에 대한 설명이 화면에 뜨도록 하기 위함
     // 구현은 Manager 클래스에 있음
    public void ClickedOn()
    {
        if (thisItem)
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription,thisItem.usable, thisItem);
        }
    }
}
