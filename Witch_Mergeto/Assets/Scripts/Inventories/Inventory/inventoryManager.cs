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

    public void openContainer(container container)
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
}

[System.Serializable]
public class containerGetter
{
    public string containerName;
    public GameObject containerPrefab;
}