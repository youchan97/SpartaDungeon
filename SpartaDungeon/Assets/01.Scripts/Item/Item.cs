using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Item : MonoBehaviour
{ 
    [SerializeField] protected ItemScriptable itemScriptable;

    public abstract void ItemAffect(Player player);

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            Player player = other.GetComponent<Player>();
            ItemAffect(player);
        }
    }
}
