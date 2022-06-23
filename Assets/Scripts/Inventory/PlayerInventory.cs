using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ����Ƽ�� �⺻���� �ִ� ��ó�� New Inventory��� ���� ���� ���� ������ menu�� ����
[CreateAssetMenu(fileName ="New Inventory", menuName = "Inventory/Palyer Inventory") ]

// ScriptableObject�� ����Ƽ���� �����ϴ� �뷮 ������ ������ ���� ������ ��(?)�̴�.
// �纻 ������ ������ �޸𸮸� ���� �� �ִ�.
// �޸𸮿� ��ũ���ͺ� ������Ʈ�� ������ �纻�� ������ �̸� �ݺ��ؼ� �����ϰ� �ǹǷ�
// �޸𸮸� ���� �� �հ� �Ǵ� ���̴�.
public class PlayerInventory : ScriptableObject
{
    // List�� ������ �÷��̾ ���� �κ��丮�� �����۵��� ó����
    public List<InventoryItem> myInventory = new List<InventoryItem>();
}
