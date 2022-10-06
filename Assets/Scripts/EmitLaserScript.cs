using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitLaserScript : MonoBehaviour
{
    public GameObject laser;
    public bool isPowered;

    GameObject actualLaser;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPowered) {
            if(!(actualLaser ?? false)) 
            {
                actualLaser = Instantiate(laser,transform);
            }
        }
        else if(actualLaser ?? false) {
            Destroy(actualLaser);
        }
    }
}
