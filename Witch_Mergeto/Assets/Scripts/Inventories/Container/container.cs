using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container
{
    private List<inventorySlot> slots = new List<inventorySlot>();
    private GameObject spawnedContainerPrefab;
    private inventory containerInventory;
    private inventory playerInventory;

    //Constructor
    public container(inventory containerInventory, inventory playerInventory)
    {
        this.containerInventory = containerInventory;
        this.playerInventory = playerInventory;
        openContainer();
    }

    public void addSlotToContainer(inventory inventory, int slotID, float x, float y, int slotSize)
    {
        GameObject spawnedSlot = Object.Instantiate(inventoryManager.INSTANCE.slotPrefab);
        inventorySlot slot = spawnedSlot.GetComponent<inventorySlot>();
        RectTransform slotRT = slot.GetComponent<RectTransform>();
        slot.setSlot(inventory, slotID, this);
        spawnedSlot.transform.SetParent(spawnedContainerPrefab.transform);
        spawnedSlot.transform.SetAsLastSibling();
        Debug.Log(spawnedSlot.transform);
        slotRT.anchoredPosition = new Vector2(x, y);
        slotRT.localPosition = new Vector3(slotRT.localPosition.x, slotRT.localPosition.y, 0);
        slotRT.localScale = new Vector3(1, 1, 1);
        slotRT.sizeDelta = Vector2.one * slotSize;
        slots.Add(slot);
    }

    public void updateSlots()
    {
        foreach(inventorySlot slot in slots)
        {
            slot.updateSlot();
        }
    }

    public void openContainer()
    {
        spawnedContainerPrefab = Object.Instantiate(getContainerPrefab(), inventoryManager.INSTANCE.transform);
    }

    public void closeContainer()
    {
        Object.Destroy(spawnedContainerPrefab);
    }
    // needs to be overridden can not be left blank or null
    public virtual GameObject getContainerPrefab()
    {
        return null;
    }

    public GameObject getSpawnedContainer()
    {
        return spawnedContainerPrefab;
    }

    public inventory getPlayerInventory()
    {
        return playerInventory;
    }



}

