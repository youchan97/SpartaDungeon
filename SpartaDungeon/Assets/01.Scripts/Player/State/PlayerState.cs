using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected Player player;
    protected PlayerStateManager stateManager;

    public PlayerState(Player player, PlayerStateManager stateManager)
    {
        this.player = player;
        this.stateManager = stateManager;
    }

    public virtual bool UseFixedUpdate() => false;
    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void ExitState() { }

}

