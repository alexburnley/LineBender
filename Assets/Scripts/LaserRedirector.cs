using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRedirector : MonoBehaviour
{
    public LaserRedirector laserRedirector;
    public Vector3 outDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getOutDirection() {
        return transform.TransformVector(outDirection);
    }

    public Vector3 getOppositeEndPosition() {
        return laserRedirector.transform.position;
    }

    public Vector3 getOppositeEndDirection() {
        return laserRedirector.getOutDirection();
    }
}
