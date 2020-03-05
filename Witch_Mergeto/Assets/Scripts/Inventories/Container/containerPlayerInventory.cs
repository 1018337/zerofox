using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class containerPlayerInventory : container
{
    private GameObject containerPrefab;
    int x = 0;
    int slotSize = 50;

    public containerPlayerInventory(inventory containerInventory, inventory playerInventory, int limitSize, int limitHeight) : base(containerInventory, playerInventory)
    {      
        for (int i = 0; i < limitSize; i++)
        {
            addSlotToContainer(playerInventory, i, ((slotSize/2) + 20) + ((slotSize + 5) * x), (Mathf.FloorToInt(i / limitHeight) * (-slotSize + -5)) + (-slotSize/2 + -20), slotSize);
            x++;
            if (x == limitHeight)
            {
                x = 0;
            }
        }
    }

    public override GameObject getContainerPrefab()
    {        
        return inventoryManager.INSTANCE.getContainerPrefab("Player Inventory");
    }
}
