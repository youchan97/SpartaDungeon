using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager
{
    private PlayerState curState;
    private Player player;

    public PlayerStateManager(Player player)
    {
        this.player = player;
    }

    public void ChangeState(PlayerState newState)
    {
        if (curState == newState)
            return;

        if(curState != null)
            curState.ExitState();
        curState = newState;
        curState.EnterState();
    }

    public void Update()
    {
        if(curState != null && curState.UseFixedUpdate() == false)
            curState.UpdateState();
    }

    public void FixedUpdate()
    {
        if (curState != null && curState.UseFixedUpdate())
            curState.FixedUpdateState();
    }
}
