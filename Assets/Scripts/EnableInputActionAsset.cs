using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnableInputActionAsset : MonoBehaviour
{
    public InputActionAsset inputActionAsset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() {
        inputActionAsset.Enable();
    }

    void OnDisable() {
        inputActionAsset.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
