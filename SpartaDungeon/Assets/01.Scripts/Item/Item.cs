using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{ 
    [SerializeField] protected ItemScriptable itemData;
    [SerializeField] protected BuffScriptable buffData;

    public ItemScriptable ItemData { get => itemData; }


    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            Destroy(this.gameObject);
            //player.TakeDamage(10f); //플레이어 hp UI 테스트용
            player.buffManager.AddBuff(buffData);
        }
    }
}
