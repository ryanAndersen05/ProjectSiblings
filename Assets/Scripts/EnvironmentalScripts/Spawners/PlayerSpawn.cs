using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
    public static int playerSpawn = 0;

    public Transform[] spawnPoints;
    public GameObject playerPrefab;

    void Awake()
    {
        if (playerSpawn >= spawnPoints.Length || playerSpawn < 0)
        {
            playerSpawn = 0;
        }
        if (spawnPoints.Length <= 0) return;
        GameObject.Instantiate(playerPrefab, spawnPoints[playerSpawn].position, Quaternion.identity);
    }
}
