using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LimitMovementtoZX : MonoBehaviour {
  public Transform imgtarget;
  //var target = this.parent;

   void Start() {
     imgtarget = transform.parent;
    //target = this.transform.parent;
    //float x = target.transform.gameObject.x;
    //float y = target.transform.position.y;
    //float z = target.transform.position.z;

 }

   void Update() {
     float x = imgtarget.transform.position.x;
     //float y = target.transform.position.y;
     float z = imgtarget.transform.position.z;

     //float r = imgtarget.transform.rotation.x;
     //float p = imgtarget.transform.rotation.y;
     //float s = imgtarget.transform.rotation.z;
     float p = imgtarget.transform.localEulerAngles.y;

     transform.position = new Vector3(x, 0, z);
     transform.eulerAngles = new Vector3(0,p,0);
 }

}
