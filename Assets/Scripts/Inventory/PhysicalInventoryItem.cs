using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    // ������Ʈ�� ���̰Դ� �ϰ� �Ͱ�
    // �ܺο��� ������ ���ϰ� �ϰ� ����.
    // ���� ����ȭ(Serialzieó��)
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    public bool leftShiftClicked; // �� shift Ŭ���� Item(����)�� get�ϱ� ����
    public GameManager theGM; 

    // �ʿ��� �� �ʱ�ȭ
    void Start()
    {
        leftShiftClicked = false; // ó���� �������� ����
        theGM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // LeftShiftŰ�� �����ų� �� �� bool ��ȭ 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            leftShiftClicked = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            leftShiftClicked = false;
        }
    }

    // enter�� ó���ϰ� �Ǹ� �� ������ shift�� �Բ� ó���Ǿ��ϹǷ�
    // stay�� ����ؾ���.
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && leftShiftClicked
            && this.gameObject.GetComponent<Interactable>().playerInRange)
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }
    // Item�� �κ��丮�� �߰��ϴ� �Լ�.
    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1; // Item ��ü�� �� ó��
                theGM.chalices++; // gamemanager���� �̼� ���θ� üũ�ϱ� ����
            }
            else
            {
                playerInventory.myInventory.Add(thisItem);
                thisItem.numberHeld += 1;
                theGM.chalices++;
            }
        }
    }
}
