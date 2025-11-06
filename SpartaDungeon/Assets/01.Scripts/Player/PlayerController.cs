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

    public Action OnMove;
    public Action OnJump;
    public Action OnRun;
    public Action OnRunEnd;

    public Vector2 moveVec;


    private void Awake()
    {
        actionController = new PlayerActionController();
        InitInputAction();
        AddInput();
        EnableInput();
    }

    public void AddInput()
    {
        moveAction.performed += MovePerformed;
        moveAction.canceled += MoveCanceled;
        jumpAction.performed += JumpPerformed;
        runAction.performed += RunPerformed;
        runAction.canceled += RunCanceled;
    }
    public void RemoveInput()
    {
        moveAction.performed -= MovePerformed;
        moveAction.canceled -= MoveCanceled;
        jumpAction.performed -= JumpPerformed;
        runAction.performed -= RunPerformed;
        runAction.canceled -= RunCanceled;
    }


    public void InitInputAction()
    {
        moveAction = actionController.Player.Move;
        jumpAction = actionController.Player.Jump;
        runAction = actionController.Player.Run;
    }

    public void EnableInput()
    {
        moveAction.Enable();
        jumpAction.Enable();
        runAction.Enable();
    }

    public void DisableInput()
    {
        moveAction.Disable();
        jumpAction.Disable();
        runAction.Disable();
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

}
