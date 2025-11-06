using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstValue;
public class Player : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] Rigidbody playerRb;
    PlayerStateManager stateManager;

    [SerializeField] float originSpeed;
    [SerializeField] float runBonusSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] bool isIdle;
    [SerializeField] bool isMove;
    [SerializeField] bool isGround;
    [SerializeField] bool isJump;
    [SerializeField] bool isRun;

    [SerializeField] float rayDistance;
    [SerializeField] LayerMask groundLayer;

    PlayerIdleState idleState;
    PlayerMoveState moveState;
    PlayerJumpState jumpState;
    PlayerRunState runState;

    #region Property
    public PlayerController Controller { get => controller; }
    public Rigidbody PlayerRb { get => playerRb; }
    public float OriginSpeed { get => originSpeed; }
    public float RunBonusSpeed { get => runBonusSpeed; }
    public float JumpPower { get => jumpPower; }
    public bool IsIdle { get => isIdle; set => isIdle = value; }
    public bool IsMove { get => isMove; set => isMove = value; }
    public bool IsGround { get => isGround; set => isGround = value; }
    public bool IsJump { get => isJump; set => isJump = value; }
    public bool IsRun { get => isRun; set => isRun = value; }
    public PlayerIdleState IdleState { get => idleState;}
    public PlayerMoveState MoveState { get => moveState;}
    public PlayerJumpState JumpState { get => jumpState;}
    public PlayerRunState RunState { get => runState; set => runState = value; }
    #endregion

    private void Awake()
    {
        stateManager = new PlayerStateManager(this);
    }

    void Start()
    {
        InitState();
        ChainAction();
        stateManager.ChangeState(IdleState);
    }

    private void Update()
    {
        stateManager.Update();
    }

    private void FixedUpdate()
    {
        stateManager.FixedUpdate();
    }
    void InitState()
    {
        idleState = new PlayerIdleState(this, stateManager);
        moveState = new PlayerMoveState(this, stateManager);
        jumpState = new PlayerJumpState(this, stateManager);
        runState = new PlayerRunState(this, stateManager);
    }


    void ChainAction()
    {
        controller.OnMove += PlayerMove;
        controller.OnJump += PlayerJump;
        controller.OnRun += PlayerRun;
        controller.OnRunEnd += PlayerRunEnd;
    }

    void RemoveChain()
    {
        controller.OnMove -= PlayerMove;
        controller.OnJump -= PlayerJump;
        controller.OnRun -= PlayerRun;
        controller.OnRunEnd -= PlayerRunEnd;
    }


    void PlayerMove()
    {
        IsMove = true;
    }

    void PlayerJump()
    {
        IsJump = true;
    }

    void PlayerRun()
    {
        IsRun = true;
    }

    void PlayerRunEnd()
    {
        IsRun = false;
    }

    public void CheckGround()
    {
        IsGround = Physics.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
    }
}

