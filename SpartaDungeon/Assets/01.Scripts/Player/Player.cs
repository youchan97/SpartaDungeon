using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] Rigidbody playerRb;
    PlayerStateManager stateManager;
    public BuffManager buffManager;
    GameCanvasManager gameCanvasManager;

    [SerializeField] float hp;
    [SerializeField] float maxHp;
    [SerializeField] float speed;
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
    public float Hp
    { 
        get => hp;
        set {  hp = value; hp = Mathf.Clamp(hp, 0f, maxHp); }
    }
    public float MaxHp { get => maxHp; }
    public float Speed { get => speed; }
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
        buffManager = new BuffManager(this);
    }

    void Start()
    {
        InitState();
        ChainAction();
        gameCanvasManager.UpdateHpBar(this);
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


    public void InitCanvas(GameCanvasManager gcm)
    {
        gameCanvasManager = gcm;
    }
    public void CheckGround()
    {
        IsGround = Physics.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
    }

    #region InputSystem
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
    #endregion

    #region ItemInteraction
    public void PlayerSpeedUp(float value) => speed += value;

    public void PlayerSpeedDown(float value) => speed -= value;

    public void PlayerJumpPowerUp(float value) => jumpPower += value;

    public void PlayerJumpPowerDown(float value) => jumpPower -= value;
    #endregion

    #region Obstacle OR Monster Interaction
    public void TakeDamage(float damage)
    {
        hp -= damage;
        gameCanvasManager.UpdateHpBar(this);
    }
    #endregion
}

