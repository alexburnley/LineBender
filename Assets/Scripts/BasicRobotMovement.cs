using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRobotMovement : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float timeToEnd;

    Ray movementDirection;
    float totalDist;

    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 direction = endPoint - startPoint;
        totalDist = direction.magnitude;

        movementDirection.origin = startPoint;
        movementDirection.direction = direction.normalized;

        currentTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        transform.position = movementDirection.GetPoint(totalDist * currentTime / timeToEnd);

        if(currentTime > timeToEnd) {
            currentTime = 0;
        }
    }
}
