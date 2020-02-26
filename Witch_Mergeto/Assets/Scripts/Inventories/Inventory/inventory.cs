using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory
{
    private List<itemStack> inventoryContents = new List<itemStack>();

    public inventory(int size)
    {
        for (int i = 0; i < size; i++)
        {
            inventoryContents.Add(new itemStack(i));
        }
    }

    public bool addItem(itemStack input)
    {
        foreach(itemStack stack in inventoryContents)
        {
            if(stack.isEmpty())
            {
                stack.setStack(input);
                return true;
            }
            else
            {
                if (itemStack.areItemsEqual(input, stack))
                {
                    if(stack.canAddTo(input.getCount()))
                    {
                        stack.increaseAmount(input.getCount());
                        return true;
                    }
                    else
                    {
                        int difference = (stack.getCount() + input.getCount()) - stack.getItem().maxStack;
                        stack.setCount(stack.getItem().maxStack);
                        input.setCount(difference);
                    }
                }
            }
        }
        return false;
    }
    public itemStack getStackInSlot(int index)
    {
        return inventoryContents[index];
    }
    // return entire content of inventory
    public List<itemStack> getInventoryStacks()
    {
        return inventoryContents;
    }
}
