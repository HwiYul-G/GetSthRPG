using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    // 컴포넌트로 보이게는 하고 싶고
    // 외부에서 연결은 못하게 하고 싶음.
    // 따라서 직렬화(Serialzie처리)
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    public bool leftShiftClicked; // 좌 shift 클릭시 Item(성배)를 get하기 위함
    public GameManager theGM; 

    // 필요한 것 초기화
    void Start()
    {
        leftShiftClicked = false; // 처음엔 눌려있지 않음
        theGM = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        // LeftShift키를 누르거나 땔 때 bool 변화 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            leftShiftClicked = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            leftShiftClicked = false;
        }
    }

    // enter로 처리하게 되면 그 순간과 shift가 함께 처리되야하므로
    // stay를 사용해야함.
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && leftShiftClicked
            && this.gameObject.GetComponent<Interactable>().playerInRange)
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }
    // Item을 인벤토리로 추가하는 함수.
    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1; // Item 자체의 수 처리
                theGM.chalices++; // gamemanager에서 미션 여부를 체크하기 위함
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
