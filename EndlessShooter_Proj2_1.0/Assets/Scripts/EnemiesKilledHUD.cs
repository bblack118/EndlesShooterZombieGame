using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesKilledHUD : MonoBehaviour
{
   // public EnemyHealth enemyHealth;
    public GameObject enemiesKilledText;

    // Update is called once per frame
    void Update()
    {
        enemiesKilledText.GetComponent<Text>().text = "Enemies Killed: " + EnemyHealth.enemiesKilled.ToString();
    }
}
