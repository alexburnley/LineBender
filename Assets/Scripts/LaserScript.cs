using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    

    const int MAX_BOUNCES = 20;
    const int MAX_DIST = 100;

    List<GameObject> previousTargets;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<LineRenderer>().useWorldSpace = true;
        previousTargets = new List<GameObject>();
    }

    void Update()
    {
        int i = 0;
        Vector3 point = transform.position;
        Vector3 direction = transform.forward;
        int layermask = 0xFFFF;
        RaycastHit raycastHit;
        List<Vector3> worldCoordPoints = new List<Vector3>();
        List<GameObject> hitTargets = new List<GameObject>();
        worldCoordPoints.Add(transform.position);

        while(i < MAX_BOUNCES) {
            if(Physics.Raycast(point, direction, out raycastHit, Mathf.Infinity, layermask))
            {
                point = raycastHit.point;
                worldCoordPoints.Add(raycastHit.point);
                i++;
                //Debug.Log(System.String.Format("laser update for : {0}, {1}", i, point.ToString()));

                if(System.String.Compare(raycastHit.collider.tag, "Reflective") == 0) {
                    direction = Vector3.Reflect(direction, raycastHit.normal);
                }
                else if(System.String.Compare(raycastHit.collider.tag, "LaserTarget") == 0) {
                    i--;
                    point += direction * .1f;
                    previousTargets.Remove(raycastHit.collider.gameObject);
                    hitTargets.Add(raycastHit.collider.gameObject);
                    raycastHit.collider.gameObject.GetComponent<LaserTarget>().onLaserCollision(true);
                }
                else if(System.String.Compare(raycastHit.collider.tag, "LaserTransparent") == 0){
                    point += direction * .1f;
                    i--;
                }
                else {
                    LaserRedirector laserRedirector = raycastHit.collider.gameObject.GetComponent<LaserRedirector>();
                    if(laserRedirector != null) {
                        point = laserRedirector.getOppositeEndPosition();
                        worldCoordPoints.Add(point);
                        direction = laserRedirector.getOppositeEndDirection();
                    }
                    // If it isn't a redirector, end the laser path
                    else break;
                }
            }
            else {
                worldCoordPoints.Add(point + direction * MAX_DIST);
                break;
            }
        }

        foreach(var target in previousTargets) {
            target.GetComponent<LaserTarget>().onLaserCollision(false);
        }
        previousTargets = hitTargets;

        var pointsArray = new Vector3[worldCoordPoints.Count];
        for(i = 0; i < worldCoordPoints.Count; i++) {
            pointsArray[i] = worldCoordPoints[i];
        }

        gameObject.GetComponent<LineRenderer>().positionCount = worldCoordPoints.Count;
        gameObject.GetComponent<LineRenderer>().SetPositions(pointsArray);
    }
}
