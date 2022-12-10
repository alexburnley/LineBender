using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredDoor : PuzzleCompleteListener
{

    public bool currentlyOpen;

    public float transitionTime;

    public GameObject leftSide;
    public Transform leftOpenPoint;
    public Transform leftClosedPoint;

    public GameObject rightSide;
    public Transform rightOpenPoint;
    public Transform rightClosedPoint;

    // Current progress through the animation
    float currentTime;

    // Essentially pointers to the start and end points of the animation. 
    // Swapping the values creates the opposite animation
    Transform leftTarget;
    Transform leftOrigin;

    Transform rightTarget;
    Transform rightOrigin;

    // Start is called before the first frame update
    void Start()
    {
        resetTargets(currentlyOpen);
        //currentTime = trans
    }

    // Update is called once per frame
    void LateFixedUpdate()
    {
        currentTime += Time.deltaTime;

        float t = currentTime / transitionTime;

        leftSide.transform.position = Vector3.Lerp(leftOrigin, leftTarget, t);
        rightSide.transform.position = Vector3.Lerp(rightOrigin, rightTarget, t);
    }

    // Listener function
    void PuzzleCompleteListener.onPuzzleEvent(bool complete) {
        
        if(complete != currentlyOpen) {
            resetTargets(complete);
            currentTime = transitionTime - currentTime;
            if(currentTime < 0) currentTime = 0;
        }
    }

    private void resetTargets(bool open) {
        if(open) {
            leftTarget = leftClosedPoint;
            leftOrigin = leftOpenPoint;
            rightTarget = rightClosedPoint;
            rightOrigin = rightOpenPoint;
        }
        else {
            leftTarget = leftOpenPoint;
            leftOrigin = leftClosedPoint;
            rightTarget = rightOpenPoint;
            rightOrigin = rightClosedPoint;
        }
    }
}
