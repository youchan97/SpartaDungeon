using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] Rigidbody playerRb;

    [SerializeField] float originSpeed;
    [SerializeField] float runSpeed;

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        
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
        Vector2 playerMoveVec = controller.moveVec;
        Vector3 vec = new Vector3(playerMoveVec.x, 0, playerMoveVec.y);
        Vector3 velocity = vec * originSpeed;
        velocity.y = playerRb.velocity.y;
        playerRb.velocity = velocity;
    }

    void PlayerJump()
    {

    }

    void PlayerRun()
    {

    }

    void PlayerRunEnd()
    {

    }
}

