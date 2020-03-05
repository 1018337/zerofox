using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemStack
{
    public static itemStack Empty = new itemStack();
    public item item;
    public int count;
    public int slotID;

    // Sets the library of items so that if they exist already in the inventory they will stack and find equal values
    // If no stack or item of type are able to be found a new stack will start
    // this system is to allow expansion later if need be to increase ability for new game items but allows for simpler systems as well

    // slot constructors
    public itemStack()
    {
        this.item = null;
        this.count = 0;
        this.slotID = -1;
    }
    // does item already have a slot assigned?
    public itemStack(int slotID)
    {
        this.item = null;
        this.count = 0;
        this.slotID = slotID;
    }
    // picking up many but no slot yet
    public itemStack(item item, int count)
    {
        this.item = item;
        this.count = count;
        this.slotID = -1;
    }
    // picking up with slot already assigned
    public itemStack(item item, int count, int slotID)
    {
        this.item = item;
        this.count = count;
        this.slotID = slotID;
    }
    // gets the item ID
    public item getItem()
    {
        return this.item;
    }
    // gets the item count
    public int getCount()
    {
        return this.count;
    }
    // makes a stack
    public void setStack(itemStack itemIn)
    {
        this.item = itemIn.getItem();
        this.count = itemIn.getCount();
    }
    // is slots empty?
    public bool isEmpty()
    {
        //Debug.Log("empty");
        return this.count < 1;
    }
    // adds to amount for slot
    public void increaseAmount(int amount)
    {
        this.count += amount;
    }
    // removes amount from slot
    public void decreaseAmount(int amount)
    {
        this.count -= amount;
    }
    // sets initial amount
    public void setCount(int amount)
    {
        Debug.Log("count" + amount);
        this.count = amount;
    }
    
    public bool canAddTo(int amount)
    {
        Debug.Log("canaddto");
        return (this.count + amount) <= this.item.maxStack;
    }
    
    // splits stack 
    public itemStack splitStack(int amount)
    {
        int i = Mathf.Min(amount, count);
        itemStack copiedStack = this.copy();
        copiedStack.setCount(i);
        this.decreaseAmount(i);
        Debug.Log("Split");
        return copiedStack;
    }
    
    //moves the item to new slot
    public itemStack copy()
    {
        Debug.Log("Copied" + this.slotID + this.item + this.count);
        return new itemStack(this.item, this.count, this.slotID);
    }

    //checks if items can stack or not
    public bool isItemEqual(itemStack stackIn)
    {
        Debug.Log("Stacking");
        return !stackIn.isEmpty() && this.item == stackIn.getItem();
    }

    // check item stacks are equal or not, if both a and b are not empty return false
    public static bool areItemsEqual(itemStack stackA, itemStack stackB)
    {
        return stackA == stackB ? true : (!stackA.isEmpty() && !stackB.isEmpty() ? stackA.isItemEqual(stackB) : false);
    }
}
