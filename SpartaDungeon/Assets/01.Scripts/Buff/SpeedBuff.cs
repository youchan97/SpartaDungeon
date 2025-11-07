using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : Buff
{
    public SpeedBuff(Player player, BuffScriptable buffData) : base(player, buffData)
    {
    }

    protected override void AffectBuffStart()
    {
        player.PlayerSpeedUp(buffData.value);
    }
    protected override void AffectBuffEnd()
    {
        player.PlayerSpeedDown(buffData.value);
    }

}
