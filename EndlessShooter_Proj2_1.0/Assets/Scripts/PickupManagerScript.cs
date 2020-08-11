using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManagerScript : MonoBehaviour
{
    public GameObject HealthPickup;
    public GameObject AmmoPickup;
    public PlayerHealth playerHealth;
    public float spawnTime = 15f;
    public Transform[] LootspawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLoot", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void SpawnLoot()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, LootspawnPoints.Length);
        int LootToSpawn = Random.Range(0, 20);

        if(LootToSpawn <= 14)
            Instantiate(AmmoPickup, LootspawnPoints[spawnPointIndex].position, LootspawnPoints[spawnPointIndex].rotation);
        else
            Instantiate(HealthPickup, LootspawnPoints[spawnPointIndex].position, LootspawnPoints[spawnPointIndex].rotation);
    }
}
