using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff
{
    protected Player player;
    protected BuffScriptable buffData;

    Coroutine coroutine;

    public Buff(Player player, BuffScriptable buffData)
    {
        this.player = player;
        this.buffData = buffData;
    }

    public void StartBuff()
    {
        coroutine = player.StartCoroutine(ApplyBuff());
    }

    public void StopBuff()
    {
        if(coroutine != null)
            player.StopCoroutine(coroutine);

        AffectBuffEnd();
    }



    IEnumerator ApplyBuff()
    {
        AffectBuffStart();
        yield return new WaitForSeconds(buffData.duration);
        AffectBuffEnd();
    }

    protected abstract void AffectBuffStart();
    protected abstract void AffectBuffEnd();
}
