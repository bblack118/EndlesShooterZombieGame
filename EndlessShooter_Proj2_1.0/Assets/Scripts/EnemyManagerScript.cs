using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject jill, sprinter, parasite;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
       

        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }
        int enemyToSpawn = Random.Range(0, 100);
        GameObject enemy;
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        if (enemyToSpawn <= 50)
            enemy = jill;
        else if (enemyToSpawn > 50 && enemyToSpawn <= 90)
            enemy = sprinter;
        else
            enemy = parasite;

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
