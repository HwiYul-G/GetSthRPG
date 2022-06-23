using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    // 컴포넌트에서 정보를 확인할 수 있도록
    [Header("Inventory Information")]
    // PlayerInventory에 담는 것을 List로 관리되는 것
    public PlayerInventory playerInventory; 
    // 직렬화(앞서 계쏙 적엇으므로 생략)
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;


    // 아이템 클릭시 text를 그 아이템에 설명을 하단으로 뜨게하고
    // 그 아이템이 사용가능한 아이템(usable = true)이라면 button이 보임
    public void SetTextAndButton(string description, bool buttonActive)
    {
        descriptionText.text = description;
        if (buttonActive) // true
        {
            useButton.SetActive(true);
        }
        else
        {
            useButton.SetActive(false);
        }
    }

    // Player가 Item을 가지게 되면 그 아이템 슬롯을 추가해서 보이게 하는 것을 계속 check함.
    // 우리에게 시각적으로 보이는 창에대한 실질적인 관리
    void MakeInventorySlots()
    {
        if (playerInventory)
        {
            for(int i = 0; i<playerInventory.myInventory.Count; i++)
            {
                if (playerInventory.myInventory[i].numberHeld > 0 || playerInventory.myInventory[i].itemName == "Bottle")
                {
                    GameObject temp
                        = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                    temp.transform.SetParent(inventoryPanel.transform);

                    InventorySlot newSlot = temp.GetComponent<InventorySlot>();

                    if (newSlot)
                    {
                        newSlot.transform.SetParent(inventoryPanel.transform);
                        newSlot.Setup(playerInventory.myInventory[i], this);
                    }
                }
            }
        }
    }

    // start나 awake는 한 번만 호출되는데
    // onEnable은 활성화 될 때마다 호출됨
    // 인벤토리 창을 여러번 Shift를 눌러서 업데이트 하면서 아이템 변화를
    // 매번 반영해주게 하기 위함
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false); 
    }

  
    // 아이템에 대한 설명이 들어가고 아이템에 따라 버튼 여부를 활성화
    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    // onEnable 될 때마다 그 슬롯에 대한 check를 하면서 쫙 지우고 다시하도록
    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    // 사용가능한 아이템일 경우 버튼이 눌리게 되면 아이템 개수 줄이는 것
    public void UseButtonPressed()
    {
        if (currentItem)
        {
            currentItem.Use();
            // Clear all of the inventory slots
            ClearInventorySlots();
            // Refill all slots with new numbers
            MakeInventorySlots();
            if (currentItem.numberHeld == 0)
            {
                SetTextAndButton("", false);
            }
        }
    }
}
