using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using static ConstValue;
public abstract class PlayerBaseMoveState : PlayerState
{
    PlayerController controller;
    Rigidbody rb;
    protected Animator anim;
    public PlayerBaseMoveState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    public override bool UseFixedUpdate() => true;
    protected virtual float GetSpeed() => player.Speed;

    public override void EnterState()
    {
        controller = player.Controller;
        rb = player.PlayerRb;
        anim = player.PlayerAnim;
    }

    public override void FixedUpdateState()
    {
        Vector2 playerMoveVec = controller.moveVec;
        Transform cameraTransform = player.PlayerCamera.gameObject.transform;
        if (player.IsJump && player.Stamina >= JumpStaminaDecrease)
        {
            stateManager.ChangeState(player.JumpState);
            return;
        }
        if (playerMoveVec.sqrMagnitude < 0.01f)
        {
            stateManager.ChangeState(player.IdleState);
            return;
        }

        if (!player.IsGround)
            stateManager.ChangeState(player.AirbornState);
        Vector3 vec = cameraTransform.TransformDirection(new Vector3(playerMoveVec.x, 0, playerMoveVec.y));
        vec.y = 0f;
        Vector3 velocity = vec * GetSpeed();
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;


    }
}
