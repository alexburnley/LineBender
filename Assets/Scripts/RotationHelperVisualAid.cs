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
    public float visibilityDistance = 2.0f;

    GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        // Assumes that there is only one object tagged with MainCamera
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        // Change visibility based on proximity to hand
        float dist = Vector3.Distance(mainCamera.transform.position, transform.position);
        Renderer cameraRenderer = gameObject.GetComponent<Renderer>();
        if(cameraRenderer != null) {
            cameraRenderer.enabled = dist < visibilityDistance;
        }
    }

    public void OnSelectEntered(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args) {
        if(interactor == null) {
            interactor = args.interactorObject;
            gameObject.GetComponentInParent<RotationHelperScript>()?.onGrab(interactor);
        }
    }

    public void OnSelectExited(UnityEngine.XR.Interaction.Toolkit.SelectExitEventArgs args) {
        if(args.interactorObject == interactor) {
            interactor = null;
            gameObject.GetComponentInParent<RotationHelperScript>()?.onRelease();
        }
    }



}
