using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBuff : Buff
{
    public JumpBuff(Player player, BuffScriptable buffData) : base(player, buffData)
    {
    }
    protected override void AffectBuffStart()
    {
        player.PlayerJumpPowerUp(buffData.value);
    }

    protected override void AffectBuffEnd()
    {
        player.PlayerJumpPowerDown(buffData.value);
    }


}
