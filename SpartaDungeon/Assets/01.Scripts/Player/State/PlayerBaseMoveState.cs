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
    protected virtual float GetSpeed() => player.Speed;

    public override void EnterState()
    {
        controller = player.Controller;
        rb = player.PlayerRb;
    }

    public override void FixedUpdateState()
    {
        //if (!player.IsGround) return;

        Vector2 playerMoveVec = controller.moveVec;
        Transform cameraTransform = player.PlayerCamera.gameObject.transform;
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
        Vector3 vec = cameraTransform.TransformDirection(new Vector3(playerMoveVec.x, 0, playerMoveVec.y));
        vec.y = 0f;
        Vector3 velocity = vec * GetSpeed();
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }
}
