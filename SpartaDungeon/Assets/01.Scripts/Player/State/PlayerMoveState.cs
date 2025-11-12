using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstValue;

public class PlayerMoveState : PlayerBaseMoveState
{
    public PlayerMoveState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    protected override float GetSpeed() => player.Speed;

    public override void EnterState()
    {
        base.EnterState();
        if (player.IsMove == false) player.IsMove = true;
        anim.SetBool(MoveAnim, true);
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        player.IncreaseStamina(MoveStaminaDuration);
        if (player.IsRun)
            stateManager.ChangeState(player.RunState);
    }


    public override void ExitState()
    {
        anim.SetBool(MoveAnim, false);
        if (player.IsRun || player.IsJump) return;
        player.IsMove = false;
    }
}
