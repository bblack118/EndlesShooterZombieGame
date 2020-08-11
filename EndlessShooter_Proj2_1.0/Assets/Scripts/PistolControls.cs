using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolControls : MonoBehaviour
{
    public bool pistolEquipped;
    static Animator anim;

    public GameObject Pistol;

    private float timer;
    public float fireRate;

    public Transform firePoint;
    public Transform crosshair;

    private AudioSource mAudioSource;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        pistolEquipped = false;
        anim = GetComponent<Animator>();
        damage = 25;
        mAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Alpha1) && !pistolEquipped)
        {
            anim.SetBool("hasPistol", true);
            Pistol.SetActive(true);
            pistolEquipped = true;
        }
         else if (Input.GetKeyDown(KeyCode.Alpha2) && pistolEquipped)
         {
            // anim.SetBool("hasPistol", false);
             Pistol.SetActive(false);
             pistolEquipped = false;
         }

         if (pistolEquipped)
         {
             timer += Time.deltaTime;
             if (timer >= fireRate)
             {
                 if (Input.GetButtonDown("Fire1"))
                 {
                     timer = 0f;
                     FirePistol();
                 }
             }
         }
        
    }

    private void FirePistol()
    {
        
         Vector3 fromPosition = firePoint.position;
         Vector3 toPosition = crosshair.position;
         Vector3 direction = toPosition - fromPosition;

        Debug.DrawRay(firePoint.position, direction, Color.red, 5f);
        Ray ray = new Ray(firePoint.position, direction);
        RaycastHit hitInfo;

        mAudioSource.Play();
        

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            if (hitInfo.collider.gameObject.tag.Equals("Enemy"))
            {
                EnemyHealth enemyHealth = hitInfo.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }

    }
}
