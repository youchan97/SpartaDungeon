using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{ 
    [SerializeField] protected ItemScriptable itemData;
    [SerializeField] protected BuffScriptable buffData;


    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            Player player = other.GetComponent<Player>();
            Destroy(this.gameObject);
            //player.TakeDamage(10f); //플레이어 hp UI 테스트용
            player.buffManager.AddBuff(buffData);
        }
    }
}
