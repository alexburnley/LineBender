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
        currentTime = transitionTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        float t = currentTime / transitionTime;

        leftSide.transform.position = Vector3.Lerp(leftOrigin.position, leftTarget.position, t);
        rightSide.transform.position = Vector3.Lerp(rightOrigin.position, rightTarget.position, t);
    }

    // Listener function
    public override void onPuzzleEvent(bool complete) {
        
        if(complete != currentlyOpen) {
            currentlyOpen = complete;
            resetTargets(complete);
            currentTime = transitionTime - currentTime;
            if(currentTime < 0) currentTime = 0;
        }
    }

    private void resetTargets(bool open) {
        if(open) {
            leftTarget = leftOpenPoint;
            leftOrigin = leftClosedPoint;
            rightTarget = rightOpenPoint;
            rightOrigin = rightClosedPoint;
        }
        else {
            leftTarget = leftClosedPoint;
            leftOrigin = leftOpenPoint;
            rightTarget = rightClosedPoint;
            rightOrigin = rightOpenPoint;
        }
    }
}
