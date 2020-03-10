using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    #region Singleton
    public static inventoryManager INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }
    #endregion

    public GameObject slotPrefab;
    public List<containerGetter> containers = new List<containerGetter>();    
    private container currentOpenContainer;
    private itemStack currentDraggedItem = itemStack.Empty;
    private GameObject spawnedDragStack;
    private inventoryDraggedItem dragItem;
    private player player;

    private void Start()
    {
        player = FindObjectOfType<player>();
        dragItem = GetComponentInChildren<inventoryDraggedItem>();
    }    

    public GameObject getContainerPrefab(string name)
    {
        foreach(containerGetter container in containers)
        {
            if(container.containerName == name)
            {
                return container.containerPrefab;
            }
        }

        return null;
    }


    public void openContainer(container container, int sizeH)
    {
        if(currentOpenContainer != null)
        {
            currentOpenContainer.closeContainer();
        }

        currentOpenContainer = container;
    }

    public void closeContainer()
    {
        if(currentOpenContainer != null)
        {
            currentOpenContainer.closeContainer();
        }
    }

    public itemStack getDraggedItem()
    {
        return currentDraggedItem;
    }

    public void setDragged(itemStack itemIn)
    {
        dragItem.setDraggedItem(currentDraggedItem = itemIn);
    }
}

[System.Serializable]
public class containerGetter
{
    public string containerName;
    public GameObject containerPrefab;
}