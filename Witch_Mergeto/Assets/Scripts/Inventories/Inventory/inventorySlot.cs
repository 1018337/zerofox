using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventorySlot : MonoBehaviour
{
    public Image itemIcon;
    public Text itemAmount;
    private int SlotID;
    private potionStack myStack;
    private container attachedContainer;
    private inventoryManager inventoryManager;

    public void setSlot(inventory attachedInventory, int SlotID, container attachedContainer)
    {
        this.SlotID = SlotID;
        this.attachedContainer = attachedContainer;
        myStack = attachedInventory.getStackInSlot(SlotID);
        inventoryManager = inventoryManager.INSTANCE;
        updateSlot();
    }

    public void updateSlot()
    {
        if(!myStack.isEmpty())
        {
            itemIcon.enabled = true;
            itemIcon.sprite = myStack.getPotion().potionIcon;

            if(myStack.getCount() > 1)
            {
                itemAmount.text = myStack.getCount().ToString();
            }
            else
            {
                itemAmount.text = string.Empty;
            }
        }
        else
        {
            itemIcon.enabled = false;
            itemAmount.text = string.Empty;
        }
    }
}
