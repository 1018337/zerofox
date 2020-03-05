using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class inventoryDraggedItem : MonoBehaviour
{
    public Image itemIcon;
    public Text itemAmount;

    public Transform target;
    public Camera cam;

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
            this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(90,90);

            if (myStack.getCount() > 1)
            {
                //Debug.Log(myStack.getItem().itemIcon);
                itemAmount.text = myStack.getCount().ToString();
            }
            else
            {
                //Debug.Log("draw stack");
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
    /*
    private void Update()
    {
        drawItem();
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y , 1);
        Debug.Log(transform.position);
    }
    */


    void Update()
    {
        drawItem();
        //Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = new Vector3(pos.x,pos.y, 1);

        // fixed screen point for camera and dragged item
        var screenPoint = Input.mousePosition;
        screenPoint.z = 100.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }
}
