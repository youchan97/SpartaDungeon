using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectManager : MonoBehaviour
{



    public void ApplyEffect(Player player, ItemScriptable item)
    {
        StartCoroutine(Effect(player, item));
    }

    IEnumerator Effect(Player player, ItemScriptable item)
    {
        //float value = item.value;
        //float coolTime = item.coolTime;
        switch(item.type)
        {
            case ItemType.SpeedUp:
                player.PlayerSpeedUp(value);
                break;
            case ItemType.JumpUp:
                player.PlayerJumpPowerUp(value);
                break;
        }

        yield return new WaitForSeconds(coolTime);

        switch (item.type)
        {
            case ItemType.SpeedUp:
                player.PlayerSpeedDown(value);
                break;
            case ItemType.JumpUp:
                player.PlayerJumpPowerDown(value);
                break;
        }
    }
}
