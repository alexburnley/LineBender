using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;
using UnityEngine.XR.Interaction.Toolkit;

public class RotationHelperVisualAid : MonoBehaviour
{

    IXRSelectInteractor interactor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: change visibility based on proximity to hand

        // TODO: detect hand grabbing visual aid and notify parent   
    }

    public void OnSelectEntered(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args) {
        //base.OnSelectEntered(args);
        //args.interactorObject.keepSelectedTargetValid = true;
        Debug.Log("onSelectEntered");
        if(interactor == null) {
            interactor = args.interactorObject;
            gameObject.GetComponentInParent<RotationHelperScript>()?.onGrab(interactor);
        }
    }

    public void OnSelectExited(UnityEngine.XR.Interaction.Toolkit.SelectExitEventArgs args) {
        //base.OnSelectExited(args);
        Debug.Log("onSelectExited");
        if(args.interactorObject == interactor) {
            interactor = null;
            gameObject.GetComponentInParent<RotationHelperScript>()?.onRelease();
        }
    }



}
