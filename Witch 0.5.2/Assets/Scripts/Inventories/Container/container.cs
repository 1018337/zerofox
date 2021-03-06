﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class container
{
    private List<inventorySlot> slots = new List<inventorySlot>();
    private GameObject spawnedContainerPrefab;
    private inventory containerInventory;
    private inventory playerInventory;

    private GameObject type;
    

    public container(inventory containerInventory, inventory playerInventory)
    {
        this.containerInventory = containerInventory;
        this.playerInventory = playerInventory;
        openContainer();
    }

    public void addSlotToContainer(inventory inventory, int slotID, float x, float y, int slotSize)
    {
        // retrieve parent, slot, information on itself;
        GameObject spawnedSlot = Object.Instantiate(inventoryManager.INSTANCE.slotPrefab);
        inventorySlot slot = spawnedSlot.GetComponent<inventorySlot>();
        RectTransform slotRT = slot.GetComponent<RectTransform>();
        slot.setSlot(inventory, slotID, this);
        // attaches slot to the main container for inventory
        spawnedSlot.transform.SetParent(spawnedContainerPrefab.transform);
        spawnedSlot.transform.SetAsFirstSibling();
        // sets the anchor position so it can reference the object
        slotRT.anchoredPosition = new Vector2(x, y);
        // sets the localpos to 0 z because otherwise it seems to fly around and it's a good backup
        slotRT.localPosition = new Vector3(slotRT.localPosition.x, slotRT.localPosition.y, 0);
        // sets the scale of each slot - scale is more like zoom
        slotRT.localScale = Vector3.one;
        // sets the size of each slot
        slotRT.sizeDelta = Vector2.one * slotSize;
        // add it to the container
        slots.Add(slot);
    }

    public void updateSlots()
    {
        //updates the slots when needed to refresh them
        foreach(inventorySlot slot in slots)
        {
            slot.updateSlot();
        }
    }

    public void openContainer()
    {
        //replace whatever container with this container so it doesn't mess with other things
        spawnedContainerPrefab = Object.Instantiate(getContainerPrefab(), inventoryManager.INSTANCE.transform);
        spawnedContainerPrefab.transform.SetAsFirstSibling();
    }

    public void closeContainer()
    {
        // blow up the container with nukes and stuff
        if (spawnedContainerPrefab != null)
        {
            if (spawnedContainerPrefab.name != "Player Inventory(Clone)")
            {
                //Debug.Log(spawnedContainerPrefab.name);
                Object.Destroy(spawnedContainerPrefab);
            }
        }
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

