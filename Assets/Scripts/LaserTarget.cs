using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTarget : MonoBehaviour
{

    public Material activeMaterial;
    public Material inactiveMaterial;


    bool active;

    LaserPuzzleScript puzzleParent;


    // Start is called before the first frame update
    void Start()
    {
        active = false;

        Transform parent = transform.parent;
        bool puzzleParentFound = false;
        while(parent != null && !puzzleParentFound) {
            if(parent.GetComponent<LaserPuzzleScript>() != null) {
                puzzleParentFound = true;
                puzzleParent = parent.GetComponent<LaserPuzzleScript>();
                puzzleParent.registerTarget(this);
            }
            else {
                parent = parent.parent;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onLaserCollision(bool collision) {
        if(collision != active) {
            active = collision;
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if(renderer != null) {
                    renderer.material = collision? activeMaterial : inactiveMaterial;
            }
            if(puzzleParent != null) {
                puzzleParent.updateValue(this, collision);
            }
        }
    }

    public bool isActive() {
        return active;
    }
}
