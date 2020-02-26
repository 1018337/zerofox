using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryDraggedItem : MonoBehaviour
{
    public Image itemIcon;
    public Text itemAmount;
        
    private itemStack myStack = itemStack.Empty;

    public void setDraggedItem(itemStack stackIn)
    {
        myStack = stackIn;
    }

    private void drawItem()
    {
        
        if (!myStack.isEmpty())
        {
            itemIcon.enabled = true;
            itemIcon.sprite = myStack.getItem().itemIcon;

            if (myStack.getCount() > 1)
            {
                Debug.Log(myStack.getItem().itemIcon);
                itemAmount.text = myStack.getCount().ToString();
            }
            else
            {
                Debug.Log("draw3");
                itemAmount.text = string.Empty;
            }
        }
        else
        {
            disableDragItem();
        }
    }

    private void disableDragItem()
    {
        itemIcon.enabled = false;
        itemAmount.text = string.Empty;
    }

    private void Update()
    {
        drawItem();
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y , 1);
    }
}
