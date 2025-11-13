using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName ="ScriptableObject/Item")]
public class ItemScriptable : ScriptableObject
{
    public string itemName;
    public string description;
    public ItemType type;
    public float consumeValue;
}
