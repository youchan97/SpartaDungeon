using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstValue;

public class PlayerAirbornState : PlayerState
{
    Animator animator;
    Rigidbody rb;
    public PlayerAirbornState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    public override bool UseFixedUpdate() => true;

    public override void EnterState()
    {
        animator = player.PlayerAnim;
        rb = player.PlayerRb;
        animator.SetTrigger(AirBornAnim);
    }

    public override void FixedUpdateState()
    {
        if(rb.velocity.y >= 0f && player.IsGround)
        {
            animator.SetTrigger(JumpEndAnim);
            if (player.IsMove && player.IsRun)
                stateManager.ChangeState(player.RunState);
            else if(player.IsMove && player.IsRun == false)
                stateManager.ChangeState(player.MoveState);
            else
                stateManager.ChangeState(player.IdleState);
        }
    }
}
