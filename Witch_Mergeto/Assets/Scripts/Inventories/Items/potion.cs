using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item")]
public class potion : ScriptableObject
{
    public string potionName;
    public Sprite potionIcon;
    public int maxStack = 1;
}
