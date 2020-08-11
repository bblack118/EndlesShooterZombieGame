using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMGAmmoText : MonoBehaviour
{
    
    public SmgControls smg;
    public GameObject smgAmmoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        smgAmmoText.GetComponent<Text>().text = smg.ammo.ToString();
    }
}
