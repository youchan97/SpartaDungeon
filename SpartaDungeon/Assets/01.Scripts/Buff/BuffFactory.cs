using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuffFactory
{
    /*private static readonly Dictionary<BuffType, Func<Player, BuffScriptable, Buff>> buffDic
        = new Dictionary<BuffType, Func<Player, BuffScriptable, Buff>>
        {
            { BuffType.Speed, (player, buffData) => new SpeedBuff(player, buffData)},
            { BuffType.Jump, (player, buffData) => new JumpBuff(player, buffData)}
        };

    public static Buff CreateBuff(Player player, BuffScriptable buffData)
    {
        if(buffDic.TryGetValue(buffData.type, out var buffCreator))
            return buffCreator(player, buffData);

        Debug.Log("버프 없음");
        return null;
    }*/

    public static Buff CreateBuff(Player player, BuffScriptable buffData)
    {
        return buffData.type switch
        {
            BuffType.Speed => new SpeedBuff(player, buffData),
            BuffType.Jump => new JumpBuff(player, buffData),
            _ => null
        };

    }
}
