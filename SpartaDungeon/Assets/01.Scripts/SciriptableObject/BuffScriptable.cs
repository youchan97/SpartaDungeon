using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuffData", menuName = "ScriptableObject/Buff")]
public class BuffScriptable : ScriptableObject
{
    public string buffName;
    public BuffType type;
    public float value;
    public float duration;
}
