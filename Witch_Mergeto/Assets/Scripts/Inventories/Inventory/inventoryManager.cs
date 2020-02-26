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
    public List<spriteGetter> backgrounds = new List<spriteGetter>();
    public List<containerGetter> containers = new List<containerGetter>();    
    private container currentOpenContainer;
    private itemStack currentDraggedItem = itemStack.Empty;
    private GameObject spawnedDragStack;
    private inventoryDraggedItem dragItem;
    
    private void Start()
    {
        dragItem = GetComponentInChildren<inventoryDraggedItem>();
    }

    public Sprite getSpritePrefab(string name)
    {
        foreach (spriteGetter backgrounds in backgrounds)
        {
            if (backgrounds.spriteName == name)
            {
                return backgrounds.spritePrefab;
            }
        }

        return null;
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

[System.Serializable]
public class spriteGetter
{
    public string spriteName;
    public Sprite spritePrefab;
}