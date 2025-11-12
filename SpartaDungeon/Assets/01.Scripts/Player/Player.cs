using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("참조 컴포넌트")]
    [SerializeField] PlayerController controller;
    [SerializeField] Rigidbody playerRb;
    [SerializeField] Animator playerAnim;
    PlayerStateManager stateManager;
    public BuffManager buffManager;
    GameManager gameManager;
    GameCanvasManager gameCanvasManager;
    [SerializeField] PlayerCameraController playerCamera;

    [Header("플레이어 능력치")]
    [SerializeField] float hp;
    [SerializeField] float maxHp;
    [SerializeField] float speed;
    [SerializeField] float runBonusSpeed;
    [SerializeField] float jumpPower;

    [Header("플레이어 상태 조건")]
    [SerializeField] bool isIdle;
    [SerializeField] bool isMove;
    [SerializeField] bool isGround;
    [SerializeField] bool isJump;
    [SerializeField] bool isRun;

    [Header("착지 판정 관련")]
    [SerializeField] float groundRayDistance;
    [SerializeField] LayerMask groundLayer;

    [Header("인터렉션 정보 관련")]
    [SerializeField] GameObject rayObj;
    [SerializeField] float objRayDistance;
    [SerializeField] float rayRadius;
    [SerializeField] LayerMask objLayer;

    PlayerIdleState idleState;
    PlayerMoveState moveState;
    PlayerJumpState jumpState;
    PlayerRunState runState;
    PlayerAirbornState airbornState;

    #region Property
    public PlayerController Controller { get => controller; }
    public Rigidbody PlayerRb { get => playerRb; }
    public Animator PlayerAnim { get => playerAnim; }
    public PlayerCameraController PlayerCamera { get => playerCamera; }
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
    public PlayerRunState RunState { get => runState;}
    public PlayerAirbornState AirbornState { get => airbornState;}
    #endregion

    private void Awake()
    {
        stateManager = new PlayerStateManager(this);
        buffManager = new BuffManager(this);
        gameManager = GameManager.Instance;
        gameManager.player = this;
    }

    void Start()
    {
        InitState();
        ChainAction();
        gameCanvasManager.UpdateHpBar(this);
        stateManager.ChangeState(IdleState);
    }

    private void OnDisable()
    {
        RemoveChain();
    }

    private void Update()
    {
        stateManager.Update();
    }

    private void FixedUpdate()
    {
        stateManager.FixedUpdate();
    }

    private void LateUpdate()
    {
        PlayerLook();
    }
    void InitState()
    {
        idleState = new PlayerIdleState(this, stateManager);
        moveState = new PlayerMoveState(this, stateManager);
        jumpState = new PlayerJumpState(this, stateManager);
        runState = new PlayerRunState(this, stateManager);
        airbornState = new PlayerAirbornState(this, stateManager);
    }


    public void InitCanvas(GameCanvasManager gcm)
    {
        gameCanvasManager = gcm;
    }

    #region InputSystem
    void ChainAction()
    {
        controller.OnMove += PlayerMove;
        controller.OnJump += PlayerJump;
        controller.OnRun += PlayerRun;
        controller.OnRunEnd += PlayerRunEnd;
        controller.OnLook += PlayerLook;
    }

    void RemoveChain()
    {
        controller.OnMove -= PlayerMove;
        controller.OnJump -= PlayerJump;
        controller.OnRun -= PlayerRun;
        controller.OnRunEnd -= PlayerRunEnd;
        controller.OnLook -= PlayerLook;
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

    void PlayerLook()
    {
        Vector2 vec = controller.lookVec;
        playerCamera.CameraRotate(vec);
    }
    #endregion
    #region Interaction Object
    public void JumpingPlayer(float value)
    {
        playerRb.AddForce(Vector3.up * value, ForceMode.Impulse);
    }
    #endregion
    #region ItemInteraction
    public void PlayerSpeedUp(float value) => speed += value;

    public void PlayerSpeedDown(float value) => speed -= value;

    public void PlayerJumpPowerUp(float value) => jumpPower += value;

    public void PlayerJumpPowerDown(float value) => jumpPower -= value;

    #endregion

    #region Pause
    public void PausePlayer()
    {
        controller.DisableInput();
        playerAnim.speed = 0f;
    }

    public void ResumePlayer()
    {
        controller.EnableInput();
        playerAnim.speed = 1f;
    }
    #endregion

    #region CheckRay
    public void CommomCheck()
    {
        CheckGround();
        CheckItemForward();
    }

    void CheckGround()
    {
        IsGround = Physics.Raycast(rayObj.transform.position, Vector3.down, groundRayDistance, groundLayer);
    }

    void CheckItemForward()
    {
        
        bool isOn = Physics.SphereCast(rayObj.transform.position,rayRadius, rayObj.transform.forward,out RaycastHit hit, objRayDistance, objLayer);
        Debug.DrawRay(rayObj.transform.position, rayObj.transform.forward * objRayDistance, Color.red);
        if (isOn)
        {
            Item item = hit.collider.GetComponent<Item>();
            if (item != null)
                gameCanvasManager.ItemDescription(item, isOn);
        }
        else
            gameCanvasManager.ItemDescription(null, isOn);
    }
    #endregion

    #region Obstacle OR Monster Interaction
    public void TakeDamage(float damage)
    {
        hp -= damage;
        gameCanvasManager.UpdateHpBar(this);
    }
    #endregion
}

