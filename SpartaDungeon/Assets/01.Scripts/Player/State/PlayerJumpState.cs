using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static ConstValue;

public class PlayerJumpState : PlayerState
{
    Rigidbody rb;
    PlayerController controller;
    float groundCoolTime;
    Animator anim;
    public PlayerJumpState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    public override bool UseFixedUpdate() => true;

    public override void EnterState()
    {
        controller = player.Controller;
        rb = player.PlayerRb;
        anim = player.PlayerAnim;
        anim.ResetTrigger(JumpEndAnim);
        anim.SetTrigger(JumpStartAnim);
        rb.AddForce(Vector3.up * player.JumpPower, ForceMode.Impulse);
        groundCoolTime = 0f;
    }

    public override void FixedUpdateState()
    {
        if (player.IsMove)
            JumpMove();
        groundCoolTime += Time.fixedDeltaTime;

        anim.SetFloat(JumpVeclocity, rb.velocity.y);

        if(player.IsGround && groundCoolTime >= GroundCheckCoolTime)
        {
            anim.SetTrigger(JumpEndAnim);
            if (player.IsMove && player.IsRun == false)
                stateManager.ChangeState(player.MoveState);
            else if (player.IsMove && player.IsRun)
                stateManager.ChangeState(player.RunState);
            else
                stateManager.ChangeState(player.IdleState);
        }
    }

    public void JumpMove()
    {
        Vector2 playerMoveVec = controller.moveVec;
        Transform cameraTransform = player.PlayerCamera.transform;
        float speed = player.IsRun ? player.Speed + player.RunBonusSpeed : player.Speed;
        speed *= AirLowSpeed;
        Vector3 vec = cameraTransform.TransformDirection(new Vector3(playerMoveVec.x, 0, playerMoveVec.y));
        vec.y = 0f;
        Vector3 velocity = vec * speed;
        velocity.y = rb.velocity.y;
        rb.velocity = Vector3.Lerp(rb.velocity, velocity, 0.1f);
    }



    public override void ExitState()
    {
        player.IsJump = false;
        groundCoolTime = 0f;
    }
}
