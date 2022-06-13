using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [Header("UI stuff to change")]
    [SerializeField] private Text itemNumberText;
    [SerializeField] private Image itemImage;


    [Header("Variables from the item")]
    public InventoryItem thisItem;
    public InventoryManager thisManager; 


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

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
