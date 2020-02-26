using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionStack
{
    public potion potion;
    public int count;
    public int slotID;

    // Sets the library of items so that if they exist already in the inventory they will stack and find equal values
    // If no stack or item of type are able to be found a new stack will start
    // this system is to allow expansion later if need be to increase ability for new game items but allows for simpler systems as well

    // slot constructors
    public potionStack()
    {
        this.potion = null;
        this.count = 0;
        this.slotID = -1;
    }
    // does potion already have a slot assigned?
    public potionStack(int slotID)
    {
        this.potion = null;
        this.count = 0;
        this.slotID = slotID;
    }
    // picking up many but no slot yet
    public potionStack(potion potion, int count)
    {
        this.potion = potion;
        this.count = count;
        this.slotID = -1;
    }
    // picking up with slot already assigned
    public potionStack(potion potion, int count, int slotID)
    {
        this.potion = null;
        this.count = count;
        this.slotID = slotID;
    }
    // gets the potion ID
    public potion getPotion()
    {
        return this.potion;
    }
    // gets the potion count
    public int getCount()
    {
        return this.count;
    }
    // makes a stack
    public void setStack(potionStack potionIn)
    {
        this.potion = potionIn.getPotion();
        this.count = potionIn.getCount();
    }
    // is slots empty?
    public bool isEmpty()
    {
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
        this.count = amount;
    }
    
    public bool canAddTo(int amount)
    {
        return (this.count + amount) <= this.potion.maxStack;
    }

    // splits stack 
    public potionStack splitStack(int amount)
    {
        int i = Mathf.Min(amount, count);
        potionStack copiedStack = this.copy();
        copiedStack.setCount(i);
        this.decreaseAmount(i);
        return copiedStack;
    }
    //moves the potion to new slot
    public potionStack copy()
    {
        return new potionStack(this.potion, this.count, this.slotID);
    }

    //checks if items can stack or not
    public bool isItemEqual(potionStack stackIn)
    {
        return !stackIn.isEmpty() && this.potion == stackIn.getPotion();
    }

    // check item stacks are equal or not, if both a and b are not empty return false
    public static bool areItemsEqual(potionStack stackA, potionStack stackB)
    {
        return stackA == stackB ? true : (!stackA.isEmpty() && !stackB.isEmpty() ? stackA.isItemEqual(stackB) : false);
    }
}
