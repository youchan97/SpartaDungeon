using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{ 
    [SerializeField] protected ItemScriptable itemData;
    [SerializeField] protected BuffScriptable buffData;

    public ItemScriptable ItemData { get => itemData; }

    protected virtual void EffectItem(Player player) { }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            Destroy(this.gameObject);
            switch(itemData.type)
            {
                case ItemType.Buff:
                    player.buffManager.AddBuff(buffData);
                    break;
                case ItemType.Consume:
                    EffectItem(player);
                    break;

            }
        }
    }
}
