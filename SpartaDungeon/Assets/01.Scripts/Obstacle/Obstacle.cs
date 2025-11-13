using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected ObstacleType type;
    [SerializeField] protected float damage;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            switch(type)
            {
                case ObstacleType.One:
                    player.TakeDamage(damage);
                    break;
                case ObstacleType.Dot:
                    break;
            }
        }
    }
}
