using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerEndInventory : container
{
    private string inventoryGUI;
    private GameObject containerPrefab;
    int x = 0;
    int slotSize = 80;

    public ContainerEndInventory(inventory containerInventory, inventory playerInventory, int limitSize, int limitHeight) : base(containerInventory, playerInventory)
    {
        for (int i = 0; i < limitSize; i++)
        {
            addSlotToContainer(playerInventory, i, ((slotSize / 2) + 20) + ((slotSize + 5) * x), (Mathf.FloorToInt(i / limitHeight) * (-slotSize + -5)) + (-slotSize / 2 + -20), slotSize);
            x++;
            if (x == limitHeight)
                x = 0;
        }
    }
    public override GameObject getContainerPrefab()
    {
        return inventoryManager.INSTANCE.getContainerPrefab("End Inventory");
    }
}