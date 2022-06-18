using UnityEngine;

public class PhysicalInventoryItem : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private InventoryItem thisItem;
    public bool leftShiftClicked;
    public GameManager theGM;

    // Start is called before the first frame update
    void Start()
    {
        leftShiftClicked = false;
        theGM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            leftShiftClicked = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            leftShiftClicked = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && leftShiftClicked
            && this.gameObject.GetComponent<Interactable>().playerInRange)
        {
            AddItemToInventory();
            Destroy(this.gameObject);
        }
    }

    void AddItemToInventory()
    {
        if (playerInventory && thisItem)
        {
            if (playerInventory.myInventory.Contains(thisItem))
            {
                thisItem.numberHeld += 1;
                theGM.chalices++;
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
