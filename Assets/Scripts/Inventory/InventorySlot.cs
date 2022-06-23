using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    // Header : ����Ƽ ������Ʈ�� �����Ǹ� ������ ��
    [Header("UI stuff to change")]
    // private�� �ܺο��� ������� ���ϰ� ����
    // serialziedField�� ����ȭ ó��(publicó�� ������Ʈ���� ���̰�)
    [SerializeField] private Text itemNumberText;
    [SerializeField] private Image itemImage;

    // Header�� ����
    [Header("Variables from the item")]
    public InventoryItem thisItem; // ����� �����̹Ƿ� ������ ó��
    public InventoryManager thisManager;  //�޴����� ��κ� ó��

    // ���Կ� ���ο� �������� �߰� �� ��, ������Ʈ�� ���� ó��
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
     // Ŭ���� �����ۿ� ���� ������ ȭ�鿡 �ߵ��� �ϱ� ����
     // ������ Manager Ŭ������ ����
    public void ClickedOn()
    {
        if (thisItem)
        {
            thisManager.SetupDescriptionAndButton(thisItem.itemDescription,thisItem.usable, thisItem);
        }
    }
}
