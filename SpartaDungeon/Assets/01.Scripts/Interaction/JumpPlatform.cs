using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    [SerializeField] float power;

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            if (Vector3.Dot(collision.contacts[0].normal, Vector3.down) > 0.5f) //플레이어에 Rigidbody가 있어서 down 방향으로설정
                player.JumpingPlayer(power);
        }
    }
}
