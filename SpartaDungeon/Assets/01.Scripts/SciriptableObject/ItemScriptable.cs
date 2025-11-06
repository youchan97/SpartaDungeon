using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName ="ScriptableObject/Item")]
public class ItemScriptable : ScriptableObject
{
    public string name;
    public string description;
    public ItemType type;
}
