using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform spawnPoint;

    [SerializeField] GameCanvasManager gameCanvasManager;
    private void Awake()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject go = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        Player player = go.GetComponent<Player>();
        SettingPlayer(player);
    }

    void SettingPlayer(Player player)
    {
        player.InitCanvas(gameCanvasManager);
    }
}
