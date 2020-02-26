using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class containerPlayerInventory : container
{
    private GameObject containerPrefab;
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
        //Sprite.Instantiate(inventoryManager.INSTANCE.getSpritePrefab("BG Main"));
    }

    public override GameObject getContainerPrefab()
    {
        return inventoryManager.INSTANCE.getContainerPrefab("Player Inventory");
    }
}
