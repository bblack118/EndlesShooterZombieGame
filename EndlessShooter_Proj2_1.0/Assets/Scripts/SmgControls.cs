using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgControls : MonoBehaviour
{
    public bool smgEquipped;
    Animator anim;

    public GameObject SMG;

    private float timer;
    public float fireRate;

    public Transform firePoint;
    public Transform crosshair;

    private AudioSource mAudioSource;

    public float damage;
    public int ammo;

    // Start is called before the first frame update
    void Start()
    {
        smgEquipped = false;
        anim = GetComponent<Animator>();
        damage = 18;
        mAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && !smgEquipped)
        {
            anim.SetBool("hasPistol", true);
            SMG.SetActive(true);
            smgEquipped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && smgEquipped)
        {
            SMG.SetActive(false);
            smgEquipped = false;
        }
       

        if (smgEquipped)
        {   
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                if (Input.GetButton("Fire1") && ammo > 0)
                {
                    timer = 0;
                    FireSmg();
                }
            }
        }

    }

    private void FireSmg()
    {

        Vector3 fromPosition = firePoint.position;
        Vector3 toPosition = crosshair.position;
        Vector3 direction = toPosition - fromPosition;

        Debug.DrawRay(firePoint.position, direction, Color.red, 5f);
        Ray ray = new Ray(firePoint.position, direction);
        RaycastHit hitInfo;
        mAudioSource.Play();

        ammo--;


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

    public void AddAmmo(int amount)
    {
        this.ammo += amount;
    }
}
