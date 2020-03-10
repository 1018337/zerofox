using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item")]
public class item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int maxStack = 30;
}
