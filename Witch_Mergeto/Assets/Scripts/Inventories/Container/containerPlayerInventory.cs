using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containerPlayerInventory : container
{
    int x = 0;
    public containerPlayerInventory(inventory containerInventory, inventory playerInventory, int limitSize, int limitHeight) : base(containerInventory, playerInventory)
    {
        for (int i = 0; i < limitSize; i++)
        {
            addSlotToContainer(playerInventory, i, 40 + (55 * x), (Mathf.FloorToInt(i / 4) * -55) + -40, 50);
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
