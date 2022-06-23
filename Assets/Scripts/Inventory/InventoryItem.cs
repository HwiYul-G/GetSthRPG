using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Unity�� ��ġ �⺻���� �ִ� ��ó��
// NewItem�̶� �� ������ Inventory/Items�� �־
// ������ �Ű� ���� �ʰ� �� �� �ְ� ��.
[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Items")]

public class InventoryItem : ScriptableObject
{
    // ������ ���� ����
    public string itemName; // �̸�
    public string itemDescription; // ����
    public Sprite itemImage; // �̹���
    public int numberHeld; // ����
    public bool usable; // ��밡���� ����������
    public bool unique; // ���� �� ������ ����
    public UnityEvent thisEvent; // ������ ��� �̺�Ʈ ó��

    // ���� ���ӿ����� ��밡���� �������� ����
    public void Use()
    {
        thisEvent.Invoke(); // ���� �̺�Ʈ ȿ�� ����
    }

    // ����  ������ ���� ����
    public void DecreaseAmount(int amountToDecrease)
    {
        numberHeld -= amountToDecrease;
        if(numberHeld < 0)
        {
            numberHeld = 0;
        }
    }

}
