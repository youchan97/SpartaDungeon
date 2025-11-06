using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseMoveState
{
    public PlayerRunState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    protected override float GetSpeed() => player.OriginSpeed + player.RunBonusSpeed;

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        if (player.IsRun == false)
            stateManager.ChangeState(player.MoveState);
    }


    public override void ExitState()
    {
        base.ExitState();
    }
}
