using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory
{
    private List<potionStack> inventoryContents = new List<potionStack>();

    public inventory(int size)
    {
        for (int i = 0; i < size; i++)
        {
            inventoryContents.Add(new potionStack(i));
        }
    }

    public bool addPotion(potionStack input)
    {
        foreach(potionStack stack in inventoryContents)
        {
            if(stack.isEmpty())
            {
                stack.setStack(input);
                return true;
            }
            else
            {
                if (potionStack.areItemsEqual(input, stack))
                {
                    if(stack.canAddTo(input.getCount()))
                    {
                        stack.increaseAmount(input.getCount());
                        return true;
                    }
                    else
                    {
                        int difference = (stack.getCount() + input.getCount()) - stack.getPotion().maxStack;
                        stack.setCount(stack.getPotion().maxStack);
                        input.setCount(difference);
                    }
                }
            }
        }
        return false;
    }
    public potionStack getStackInSlot(int index)
    {
        return inventoryContents[index];
    }
    // return entire content of inventory
    public List<potionStack> getInventoryStacks()
    {
        return inventoryContents;
    }
}
