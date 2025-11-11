using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstValue;
public class PlayerRunState : PlayerBaseMoveState
{
    public PlayerRunState(Player player, PlayerStateManager stateManager) : base(player, stateManager)
    {
    }

    protected override float GetSpeed() => player.Speed + player.RunBonusSpeed;

    public override void EnterState()
    {
        base.EnterState();
        player.PlayerAnim.SetBool(RunAnim, true);
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
        player.PlayerAnim.SetBool(RunAnim, false);
    }
}
