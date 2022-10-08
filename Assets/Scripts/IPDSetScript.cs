using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPDSetScript : MonoBehaviour {

  public Camera leftEyeCamera;
  public Camera rightEyeCamera;
  // IPD variable set to average value ().1 - 0.1)
  public float IPD = 0.08f;
  public float changeIPD = 0.01f;

    // Set camera positions at Start
    void Start(){
      leftEyeCamera.transform.localPosition -= new Vector3(IPD/2, 0, 0);
      rightEyeCamera.transform.localPosition += new Vector3(IPD/2, 0, 0);
    }

    // change IPD value +.01 or -.01 with E and Q
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
          leftEyeCamera.transform.localPosition -= new Vector3(changeIPD, 0, 0);
          rightEyeCamera.transform.localPosition += new Vector3(changeIPD, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
          leftEyeCamera.transform.localPosition += new Vector3(changeIPD, 0, 0);
          rightEyeCamera.transform.localPosition -= new Vector3(changeIPD, 0, 0);
        }
    }
}
