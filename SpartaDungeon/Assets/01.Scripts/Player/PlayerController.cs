using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerActionController actionController;

    InputAction moveAction;
    InputAction jumpAction;
    InputAction runAction;
    InputAction lookAction;
    InputAction pauseAction;

    public Action OnMove;
    public Action OnJump;
    public Action OnRun;
    public Action OnRunEnd;
    public Action OnLook;
    public Action OnPause;

    public Vector2 moveVec;

    public Vector2 lookVec;

    private void Awake()
    {
        actionController = new PlayerActionController();
        InitInputAction();
        AddInput();
        EnableInput();
    }

    private void OnDisable()
    {
        RemoveInput();
    }


    public void AddInput()
    {
        moveAction.performed += MovePerformed;
        moveAction.canceled += MoveCanceled;
        jumpAction.performed += JumpPerformed;
        runAction.performed += RunPerformed;
        runAction.canceled += RunCanceled;
        lookAction.performed += LookPerformed;
        lookAction.canceled += LookCanceled;
        pauseAction.performed += PausePerformed;
    }
    public void RemoveInput()
    {
        moveAction.performed -= MovePerformed;
        moveAction.canceled -= MoveCanceled;
        jumpAction.performed -= JumpPerformed;
        runAction.performed -= RunPerformed;
        runAction.canceled -= RunCanceled;
        lookAction.performed += LookPerformed;
        lookAction.canceled += LookCanceled;
        pauseAction.performed -= PausePerformed;
    }


    public void InitInputAction()
    {
        moveAction = actionController.Player.Move;
        jumpAction = actionController.Player.Jump;
        runAction = actionController.Player.Run;
        lookAction = actionController.Player.Look;

    }

    public void EnableInput()
    {
        moveAction.Enable();
        jumpAction.Enable();
        runAction.Enable();
        lookAction.Enable();
    }

    public void DisableInput()
    {
        moveAction.Disable();
        jumpAction.Disable();
        runAction.Disable();
        lookAction.Disable();
    }


    void MovePerformed(InputAction.CallbackContext context)
    {
        moveVec = context.ReadValue<Vector2>();
        OnMove?.Invoke();
    }

    void MoveCanceled(InputAction.CallbackContext context)
    {
        moveVec = Vector2.zero;
        OnMove?.Invoke();
    }

    void JumpPerformed(InputAction.CallbackContext context)
    {
        OnJump?.Invoke();
    }


    void RunPerformed(InputAction.CallbackContext context)
    {
        OnRun?.Invoke();
    }

    void RunCanceled(InputAction.CallbackContext context)
    {
        OnRunEnd?.Invoke();
    }

    void LookPerformed(InputAction.CallbackContext context)
    {
        lookVec = context.ReadValue<Vector2>();
        OnLook?.Invoke();
    }

    void LookCanceled(InputAction.CallbackContext context)
    {
        lookVec = Vector2.zero;
        OnLook?.Invoke();
    }

    void PausePerformed(InputAction.CallbackContext context)
    {
        OnPause?.Invoke();
    }
}
