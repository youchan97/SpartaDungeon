using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager
{
    Player player;
    List<Buff> buffLists = new List<Buff>();

    public BuffManager(Player player)
    {
        this.player = player;
    }

    public void AddBuff(BuffScriptable buffData)
    {
        Buff newBuff = BuffFactory.CreateBuff(player, buffData);
        if (newBuff == null) return;

        buffLists.Add(newBuff);
        newBuff.StartBuff();
    }
}
