using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containerPlayerInventory : container
{
    public containerPlayerInventory(inventory containerInventory, inventory playerInventory) : base (containerInventory, playerInventory)
    {
        //Adding slots

    }

    public override GameObject getContainerPrefab()
    {
        return inventoryManager.INSTANCE.getContainerPrefab("Player Inventory");
    }
}
