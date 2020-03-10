using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containerEnd : MonoBehaviour
{
    public static int limitSize = 4;
    public static int limitHeight = 4;
    private player player;
    private inventoryManager inventoryManager;
    public inventory inventory = new inventory(3);
    private item[] itemsToAdd;

    void Start()
    {
        player = FindObjectOfType<player>();
        inventoryManager = inventoryManager.INSTANCE;
    }
    private void OnMouseOver()
    {        
        if(Input.GetMouseButtonDown(1))//right click
        {
            inventoryManager.openContainer(new ContainerEndInventory(inventory, inventory, 3, 4), 2);
        }
    }
    

    public string Check()
    {
        string checker = "";
        List<itemStack> items = new List<itemStack>();
        items = inventory.getInventoryStacks();
        //Debug.Log(items.Count);
        foreach (itemStack item in items)
        {
            if (item.item != null)
            {           
                checker += item.item.ToString().Substring(7, 1);
            }
        }
        return checker;
        //Debug.Log(checker + " result");
    }

    public void resetContainer()
    {
        List<itemStack> items = inventory.getInventoryStacks();
        foreach (itemStack item in items)
        {
            if (item.item != null)
            {
                inventory.remAll();
            }
        }
        items = new List<itemStack>();
        inventory = new inventory(3);
    }
}
