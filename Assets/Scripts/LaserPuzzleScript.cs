using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPuzzleScript : MonoBehaviour
{

    Dictionary<LaserTarget, bool> targets = new Dictionary<LaserTarget, bool>();

    bool complete = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void registerTarget(LaserTarget target) {
        targets.Add(target, false);
    }

    public void updateValue(LaserTarget target, bool targetActive) {
        targets[target] = targetActive;

        bool nowComplete = true;
        foreach(bool active in targets.Values) {
            nowComplete = nowComplete && active;
        }

        complete = nowComplete;

        //Debug.Log(System.String.Format("Puzzle Complete? : {0}",complete));
    }

    public bool getComplete() {
        return complete;
    }
}
