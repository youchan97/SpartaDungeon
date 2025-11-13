using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstValue;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    public override void EnterState()
    {
        player.IsIdle = true;
        player.PlayerAnim.SetBool(IdleAnim, true);
    }

    public override void UpdateState()
    {
        player.IncreaseStamina(IdleStaminaDuration);
        if (player.IsMove)
        {
            stateManager.ChangeState(player.MoveState);
            return;
        }
        else if (player.IsJump && player.Stamina >= JumpStaminaDecrease)
        {
            stateManager.ChangeState(player.JumpState);
            return;
        }

        if (!player.IsGround && player.IsJump != false)
            stateManager.ChangeState(player.AirbornState);
    }

    public override void ExitState()
    {
        player.IsIdle = false;
        player.PlayerAnim.SetBool(IdleAnim, false);
    }
}
