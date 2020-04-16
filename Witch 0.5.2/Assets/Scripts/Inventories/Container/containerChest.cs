using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containerChest : MonoBehaviour
{
    public static int limitSize = 4;
    public static int limitHeight = 4;
    private player player;
    private inventoryManager inventoryManager;
    private ContainerChestInventory ContainerChestInventory;
    public inventory inventory = new inventory(3);
    bool isOpen;
    private item[] itemsToAdd;

    void Start()
    {
        player = FindObjectOfType<player>();
        inventoryManager = inventoryManager.INSTANCE;
    }

    public void addItems(item items)
    {
        //Debug.Log(items);
        inventory.addItem(new itemStack(items, 1));
    }

    private void OnMouseOver()
    {        
        if(Input.GetMouseButtonDown(1))//right click
        {
            inventoryManager.openContainer(new ContainerChestInventory(inventory, inventory, 3, 4), 2);
        }
    }
}
