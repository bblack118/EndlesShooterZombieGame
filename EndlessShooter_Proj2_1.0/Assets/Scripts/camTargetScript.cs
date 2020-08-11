using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTargetScript : MonoBehaviour
{
    private Vector3 camPlacement;
    public GameObject player;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        camPlacement = new Vector3(player.transform.position.x, player.transform.position.y + 2.2f, player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, camPlacement, 100 * Time.deltaTime);
       
    }
}
