using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHelper : MonoBehaviour
{

    public GameObject anchor;

    bool currentlyHolding;

    UnityEngine.XR.Interaction.Toolkit.IXRHoverInteractable hoverObject;

    
    // Start is called before the first frame update
    void Start()
    {
        currentlyHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!currentlyHolding && hoverObject != null) {
            transform.position = hoverObject.transform.position;
            transform.rotation = hoverObject.transform.rotation;
        }
    }


    public void OnHoverEntered(UnityEngine.XR.Interaction.Toolkit.HoverEnterEventArgs args) {

        if(!currentlyHolding) {
            hoverObject = args.interactableObject;
            transform.position = hoverObject.transform.position;
            transform.rotation = hoverObject.transform.rotation;
        }
    }

    public void OnHoverExited(UnityEngine.XR.Interaction.Toolkit.HoverExitEventArgs args) {
        hoverObject = null;
    }

    public void OnSelectEntered(UnityEngine.XR.Interaction.Toolkit.SelectEnterEventArgs args) {
        
        currentlyHolding = true;
    }

    public void OnSelectExited(UnityEngine.XR.Interaction.Toolkit.SelectExitEventArgs args) {
        currentlyHolding = false;
    }
}
