using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isOpen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(!isOpen)
            {
                inventoryManager.INSTANCE.openContainer(new containerPlayerInventory(null, null));
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
