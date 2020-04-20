using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_spawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;

    // Use this for initialization
    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 1f, 1.5f);
    }

    void SpawnAMonster()
    {
        float randomScale = Random.Range(2f, 5f);
        randomScale = ((int)randomScale) / 10f;

        if (spawnAllowed && planet.healthAmount>0)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            GameObject met = Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position,
                Quaternion.identity);

            met.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }

    }
}
