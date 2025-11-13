using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaItem : Item
{
    [SerializeField] float upValue;
    protected override void EffectItem(Player player)
    {
        player.PlayerStaminaUp(upValue);
    }
}
