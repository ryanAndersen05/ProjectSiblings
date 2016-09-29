using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
    public static int playerSpawn = 0;

    public Transform[] spawnPoints;
    public GameObject playerPrefab;

    void Awake()
    {
        GameObject.Instantiate(playerPrefab, spawnPoints[playerSpawn].position, Quaternion.identity);
    }
}
