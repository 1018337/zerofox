using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public static int limitSize = 10;
    public static int limitHeight = 4;
    private inventory myInventory = new inventory(limitSize);
    private bool isOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!isOpen)
            {
                inventoryManager.INSTANCE.openContainer(new containerPlayerInventory(null, myInventory, limitSize, limitHeight));
                isOpen = true;
            }
            else 
            {
                inventoryManager.INSTANCE.closeContainer();
                isOpen = false;
            }
        }
    }
}
