using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearAndReset : MonoBehaviour
{
    public List<GameObject> containers = new List<GameObject>();
    public item[] itemsToAdd;
    private containerChest containerChest;
    public GameObject containerEnd;

    #region Singleton
    public static clearAndReset INSTANCE;

    private void Awake()
    {
        INSTANCE = this;
    }
    #endregion

    public void jumbleContainers()
    {
        containerEnd.GetComponent<containerEnd>().resetContainer();
        //Debug.Log(containers.Count);
        for (int i = 0; i < containers.Count; i++)
        {
            GameObject temp = containers[i];
            int randomIndex = Random.Range(i, containers.Count);
            containers[i] = containers[randomIndex];
            containers[randomIndex] = temp;
        }
        string str = "";
        for (int i = 0; i < containers.Count; i++)
        {
            str += containers[i].ToString();
        }
        //Debug.Log(str);
        deployItems();
    }

    private void deployItems()
    {
        for (int i = 0; i < itemsToAdd.Length; i++)
        {
            containers[i].GetComponent<containerChest>().addItems(itemsToAdd[i]);
        }
    }
}
