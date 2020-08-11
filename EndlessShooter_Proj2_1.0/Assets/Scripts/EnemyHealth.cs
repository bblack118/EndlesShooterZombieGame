using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float startingHealth = 100;
    public float currentHealth;

    public float timer;
   
    bool isDead;
    bool isShot = false;

    public Animator zAnim;
    NavMeshAgent agent;
    public static int enemiesKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = startingHealth;
        
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {

      //  Debug.Log("EnemiesKilled: " + enemiesKilled.ToString());
        if (isShot)
        {
            timer += Time.deltaTime;
            agent.enabled = false;
            if (timer >= 2.0f)
            {
                isShot = false;
                zAnim.SetBool("isHit", false);
                agent.enabled = true;
                timer = 0.0f;
            }
        }
        if (isDead)
        {
            agent.enabled = false;
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        this.isShot = true;
        zAnim.SetBool("isHit", true);
        
        this.currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        this.isDead = true;
        zAnim.SetBool("isDead", true);
        agent.enabled = false;
        enemiesKilled++;
        
        Destroy(gameObject, 4.2f);
        
    }
}
