using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public abstract class PlayerBaseMoveState : PlayerState
{
    PlayerController controller;
    Rigidbody rb;
    public PlayerBaseMoveState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    public override bool UseFixedUpdate() => true;
    protected virtual float GetSpeed() => player.OriginSpeed;

    public override void EnterState()
    {
        controller = player.Controller;
        rb = player.PlayerRb;
    }

    public override void FixedUpdateState()
    {
        //if (!player.IsGround) return;

        Vector2 playerMoveVec = controller.moveVec;
        if (player.IsJump)
        {
            stateManager.ChangeState(player.JumpState);
            return;
        }
        if (playerMoveVec.sqrMagnitude < 0.01f)
        {
            stateManager.ChangeState(player.IdleState);
            return;
        }
        Vector3 vec = new Vector3(playerMoveVec.x, 0, playerMoveVec.y);
        Vector3 velocity = vec * GetSpeed();
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
