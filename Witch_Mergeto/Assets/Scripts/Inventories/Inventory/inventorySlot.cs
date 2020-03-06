using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventorySlot : MonoBehaviour, IPointerDownHandler
{
    public Image itemIcon;
    public Text itemAmount;
    private int SlotID;
    private itemStack myStack;
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
            itemIcon.sprite = myStack.getItem().itemIcon;

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

    private void setSlotContents(itemStack stackIn)
    {
        myStack.setStack(stackIn);
        updateSlot();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        itemStack currentDraggedStack = inventoryManager.getDraggedItem();
        itemStack stackCopy = myStack.copy();

        if(eventData.pointerId == -1)
        {
            onLeftClick(currentDraggedStack, stackCopy);
        }
        //throw new System.NotImplementedException();
    }

    private void onLeftClick(itemStack currentDraggedItem, itemStack itemCopy)
    {
        if(!myStack.isEmpty() && currentDraggedItem.isEmpty())
        {
            inventoryManager.setDragged(itemCopy);
            this.setSlotContents(itemStack.Empty);
        }

        if (myStack.isEmpty() && !currentDraggedItem.isEmpty())
        {
            this.setSlotContents(currentDraggedItem);
            inventoryManager.setDragged(itemStack.Empty);
        }
        if(!myStack.isEmpty() && !currentDraggedItem.isEmpty())
        {
            if(itemStack.areItemsEqual(itemCopy, currentDraggedItem))
            {
                if(itemCopy.canAddTo(currentDraggedItem.getCount()))
                {
                    itemCopy.increaseAmount(currentDraggedItem.getCount());
                    this.setSlotContents(itemCopy);
                    inventoryManager.setDragged(itemStack.Empty);
                }
                else
                {
                    int difference = (itemCopy.getCount() + currentDraggedItem.getCount()) - itemCopy.getItem().maxStack;
                    itemCopy.setCount(myStack.getItem().maxStack);
                    itemStack dragCopy = currentDraggedItem.copy();
                    dragCopy.setCount(difference);
                    this.setSlotContents(itemCopy);
                    inventoryManager.setDragged(dragCopy);
                }
            }
            else
            {
                itemStack currentDragCopy = currentDraggedItem.copy();
                this.setSlotContents(currentDraggedItem);
                inventoryManager.setDragged(itemCopy);
            }
        }
    }
}
