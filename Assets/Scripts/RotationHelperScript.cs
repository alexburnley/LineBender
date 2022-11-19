using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationHelperScript : MonoBehaviour
{

    IXRSelectInteractor manipulator;

    Vector3 initialManipulatorPosition; // Relative position of manipulator on grab
    Quaternion parentInitialRotation; // parent rotation on grab
    Plane plane;
    public GameObject rotationHelperVisual;
    public Vector3 rotationAxis;

    // Start is called before the first frame update
    void Start()
    {
        rotationHelperVisual = Instantiate(rotationHelperVisual, transform);
        plane = new Plane(new Vector3(0,0,1),new Vector3(0,0,0));
        //onGrab(manipulator);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Add logic for showing and hiding the rotationHelperVisual based on hand proximity


        if(manipulator != null) {

            plane.SetNormalAndPosition(parentInitialRotation * rotationAxis, transform.position);

            Vector3 initialPointOnPlane = plane.ClosestPointOnPlane(transform.position + initialManipulatorPosition);
            Vector3 currentPointOnPlane = plane.ClosestPointOnPlane(manipulator.transform.position);
            float angle = Vector3.SignedAngle(initialPointOnPlane - transform.position, currentPointOnPlane - transform.position, parentInitialRotation * rotationAxis);
            
            transform.rotation = Quaternion.AngleAxis(angle, parentInitialRotation * rotationAxis) * parentInitialRotation ;

        }


        // Reset rotation helper visual aid position and rotation.
        rotationHelperVisual.transform.localPosition = Vector3.zero;

        Quaternion q = new Quaternion();
        q.SetFromToRotation(Vector3.up, rotationAxis);
        rotationHelperVisual.transform.localRotation = q;
    }


    public void onGrab(IXRSelectInteractor manipulator) {
        this.manipulator = manipulator;
        initialManipulatorPosition = manipulator.transform.position - transform.position;
        parentInitialRotation = transform.rotation;
        //manipulatorActive = true;
    }

    public void onRelease() {
        manipulator = null;
        //manipulatorActive = false;
    }
}
