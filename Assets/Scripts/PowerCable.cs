using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCable : MonoBehaviour
{

    public Material activeMaterial;
    public Material inactiveMaterial;

    public int minimumNumActivatedTargets = 1;

    int numTargets;
    // Start is called before the first frame update
    void Start()
    {
        numTargets = 1 - minimumNumActivatedTargets;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPowerEvent(bool powered) {

        numTargets += powered? 1 : -1;

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if(renderer != null) {
                renderer.material = numTargets > 0? activeMaterial : inactiveMaterial;
        }
    }
}
