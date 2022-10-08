using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitchScript : MonoBehaviour {
    public Camera cam1;
    public Camera cam2;

    // set Cam1 to on
    void Start() {
        cam1.enabled = true;
        cam2.enabled = false;
    }
    // change camera view with C
    void Update() {
        if (Input.GetKeyDown(KeyCode.C)) {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }
    }

}
