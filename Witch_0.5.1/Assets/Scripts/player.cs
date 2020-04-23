using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public static int limitSize = 4;
    public static int limitHeight = 4;
    public item[] itemsToAdd;
    private inventory myInventory = new inventory(limitSize);
    private bool isOpen;


    private void Start()
    {
        foreach(item item in itemsToAdd)
        {
            myInventory.addItem(new itemStack(item, 1));
        }

        inventoryManager.INSTANCE.openContainer(new containerPlayerInventory(null, myInventory, limitSize, limitHeight), limitHeight);
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!isOpen)
            {
                inventoryManager.INSTANCE.openContainer(new containerPlayerInventory(null, myInventory, limitSize, limitHeight), limitHeight);
                isOpen = true;
            }
            else 
            {
                inventoryManager.INSTANCE.closeContainer();
                isOpen = false;
            }
        }
        */
    }

    public inventory getInventory()
    {
        return myInventory;
    }
}
