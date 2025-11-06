using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    Rigidbody rb;
    float groundCoolTime;
    public PlayerJumpState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    public override bool UseFixedUpdate() => true;

    public override void EnterState()
    {
        rb = player.PlayerRb;
        rb.AddForce(Vector3.up * player.JumpPower, ForceMode.Impulse);
        groundCoolTime = 0f;
    }

    public override void FixedUpdateState()
    {
        groundCoolTime += Time.fixedDeltaTime;
        if(player.IsGround && groundCoolTime >= 0.2f)
        {
            if (player.IsMove && player.IsRun == false)
                stateManager.ChangeState(player.MoveState);
            else if (player.IsMove && player.IsRun)
                stateManager.ChangeState(player.RunState);
            else
                stateManager.ChangeState(player.IdleState);
        }
    }

    public override void ExitState()
    {
        player.IsJump = false;
        groundCoolTime = 0f;
    }
}
