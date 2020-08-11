using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatControls : MonoBehaviour
{
    static Animator anim;

    public float speed = 10.0F;
    public float rotationSpeed = 100.0f;
    public int HealthPickupAmount = 25;
    public int AmmoPickupAmount = 30;

    PlayerHealth playerHealth;
    SmgControls smg;

    
    private Collider collider;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        playerHealth = GetComponent<PlayerHealth>();
        smg = GetComponent<SmgControls>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;

        transform.Translate(playerMovement, Space.Self);
       

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }

        //Strafing
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isStrafingLeft", true);
        }
        else
        {
            anim.SetBool("isStrafingLeft", false);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isStrafingRight", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isStrafingRight", false);
            
        }
        //Moving forwards or backwards
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isMovingBackwards", true);
        }
        else
        {
            anim.SetBool("isMovingBackwards", false);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isIdle", false);
        }
        else
            anim.SetBool("isIdle", true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthPickUp"))
        {
            playerHealth.AddHealth(HealthPickupAmount);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("AmmoPickUp"))
        {
            smg.AddAmmo(AmmoPickupAmount);
            other.gameObject.SetActive(false);
        }
    }
}
 