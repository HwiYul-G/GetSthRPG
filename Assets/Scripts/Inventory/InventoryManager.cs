using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    // ������Ʈ���� ������ Ȯ���� �� �ֵ���
    [Header("Inventory Information")]
    // PlayerInventory�� ��� ���� List�� �����Ǵ� ��
    public PlayerInventory playerInventory; 
    // ����ȭ(�ռ� ��� �������Ƿ� ����)
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private Text descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;


    // ������ Ŭ���� text�� �� �����ۿ� ������ �ϴ����� �߰��ϰ�
    // �� �������� ��밡���� ������(usable = true)�̶�� button�� ����
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

    // Player�� Item�� ������ �Ǹ� �� ������ ������ �߰��ؼ� ���̰� �ϴ� ���� ��� check��.
    // �츮���� �ð������� ���̴� â������ �������� ����
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

    // start�� awake�� �� ���� ȣ��Ǵµ�
    // onEnable�� Ȱ��ȭ �� ������ ȣ���
    // �κ��丮 â�� ������ Shift�� ������ ������Ʈ �ϸ鼭 ������ ��ȭ��
    // �Ź� �ݿ����ְ� �ϱ� ����
    void OnEnable()
    {
        ClearInventorySlots();
        MakeInventorySlots();
        SetTextAndButton("", false); 
    }

  
    // �����ۿ� ���� ������ ���� �����ۿ� ���� ��ư ���θ� Ȱ��ȭ
    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem)
    {
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    // onEnable �� ������ �� ���Կ� ���� check�� �ϸ鼭 �� ����� �ٽ��ϵ���
    void ClearInventorySlots()
    {
        for(int i = 0; i < inventoryPanel.transform.childCount; i++)
        {
            Destroy(inventoryPanel.transform.GetChild(i).gameObject);
        }
    }

    // ��밡���� �������� ��� ��ư�� ������ �Ǹ� ������ ���� ���̴� ��
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
