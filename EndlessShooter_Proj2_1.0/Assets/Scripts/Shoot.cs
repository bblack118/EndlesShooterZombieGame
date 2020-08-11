using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hitInfo;
            Physics.Raycast(transform.position, transform.forward, out hitInfo);

            if (hitInfo.collider.gameObject.name.Equals("Badguy"))
            {
                hitInfo.collider.gameObject.SetActive(false);
            }
           
        }

    }
}
