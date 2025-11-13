using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : Item
{
    protected override void EffectItem(Player player)
    {
        player.PlayerHealHp(itemData.consumeValue);
    }
}
