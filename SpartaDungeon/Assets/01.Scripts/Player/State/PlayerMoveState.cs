using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseMoveState
{
    public PlayerMoveState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    protected override float GetSpeed() => player.OriginSpeed;

    public override void EnterState()
    {
        base.EnterState();
        if (player.IsMove == false) player.IsMove = true;
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        if (player.IsRun)
            stateManager.ChangeState(player.RunState);
    }


    public override void ExitState()
    {
        if (player.IsRun) return;
        player.IsMove = false;
    }
}
