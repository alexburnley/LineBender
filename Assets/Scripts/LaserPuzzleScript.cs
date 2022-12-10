using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPuzzleScript : PuzzleCompleteListener
{

    Dictionary<LaserTarget, bool> targets = new Dictionary<LaserTarget, bool>();

    bool complete = false;


    public bool enableEmitterByDefault = false;
    public EmitLaserScript laserForPuzzle;

    public PuzzleCompleteListener[] listeners;

    public PowerCable[] connectedCables;

    // Start is called before the first frame update
    void Start()
    {
        laserForPuzzle?.setPowered(enableEmitterByDefault);
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

        if(complete != nowComplete){
            for(int i = 0; i < listeners.Length; i++) {
                listeners[i].onPuzzleEvent(nowComplete);
            }

            for(int i = 0; i < connectedCables.Length; i++) {
                connectedCables[i].onPowerEvent(nowComplete);
            }
        }

        complete = nowComplete;

        //Debug.Log(System.String.Format("Puzzle Complete? : {0}",complete));
    }

    public bool getComplete() {
        return complete;
    }

    // Listener function
    public override void onPuzzleEvent(bool complete) {
        laserForPuzzle?.setPowered(complete);
    }
}
