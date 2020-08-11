using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehavior : MonoBehaviour
{

    public float speed;
    private Vector3 zombiePos;
    

    NavMeshAgent agent;

    public Animator zAnim;
    private bool isRunning;

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public bool inRange = false;
    GameObject player1;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    public float timer;

   

    // Start is called before the first frame update
    void Start()
    {
       
        isRunning = true;
        agent = GetComponent<NavMeshAgent>();
        player1 = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player1.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled)
            agent.SetDestination(player1.transform.position);
       

        if (Vector3.Distance(player1.transform.position, this.transform.position) < 7)
        {
            Vector3 direction = player1.transform.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.2f);
        }


        if (Vector3.Distance(player1.transform.position, this.transform.position) < 3)
            {
                timer += Time.deltaTime;
                inRange = true;
                zAnim.SetBool("isClose", true);
                if (timer >= timeBetweenAttacks && inRange)
                {
                    agent.enabled = false;
                    Attack();
                }
                
            }
            else
            {
                zAnim.SetBool("isClose", false);
                inRange = false;
                agent.enabled = true;
            }
        
            
        
    }

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
            playerHealth.TakeDamage(attackDamage);
        
    }

 

}
