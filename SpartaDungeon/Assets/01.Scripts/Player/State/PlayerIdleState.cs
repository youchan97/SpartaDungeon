using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    public override void EnterState()
    {
        player.IsIdle = true;
    }

    public override void UpdateState()
    {
        if (player.IsMove)
            stateManager.ChangeState(player.MoveState);
        else if (player.IsJump)
            stateManager.ChangeState(player.JumpState);
    }

    public override void ExitState()
    {
        player.IsIdle = false;
    }
}
