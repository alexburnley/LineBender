using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    // Enable or disable chasing and killing the player
    public bool huntPlayer = true;

    // Path of points to patrol along.
    public Transform[] patrolPath;
    // Field of view in which the player can be seen
    public float fieldOfView;
    // Maximum distance that the player can be seen from
    public float viewDistance;
    // Distance at which the player is killed and the game is ended
    public float killDistance;
    public float chaseSpeed = 3.5f;
    public float patrolSpeed = 1.5f;
    
    // Configuration for the light the robot uses
    public GameObject light;
    private Light lightComponent;
    public Color lightChaseColor;
    public Color lightPatrolColor;

    // Configuration for the sound the robot plays while patrolling and chasing
    public AudioSource audioSource;
    public AudioClip patrolAudioClip;
    public float patrolTimeBetweenPlays = 1f;
    public float patrolVolume = .75f;
    public AudioClip chaseAudioClip;
    public float chaseTimeBetweenPlays = 0f;
    public float chaseVolume = 1f;

    float timeSinceLastPlay;


    UnityEngine.AI.NavMeshAgent agent;
    Transform currentTarget;
    int currentPathIndex;
    
    GameObject playerCamera;


    bool isChasing;

    
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(patrolPath.Length > 0) {
            currentTarget = patrolPath[0];
            agent.destination = patrolPath[0].position;
            currentPathIndex = 0;
        }
        else {
            currentTarget = transform;
            agent.destination = transform.position;
        }
        lightComponent = light.GetComponent<Light>();
        playerCamera = GameObject.FindWithTag("MainCamera");
        agent.speed = patrolSpeed;
        isChasing = false;
        lightComponent.color = lightPatrolColor;

        patrolTimeBetweenPlays += patrolAudioClip.length;
        chaseTimeBetweenPlays += chaseAudioClip.length;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is visible. 
        bool visible = false;

        if(huntPlayer) {
            visible = determinePlayerVisible();
        }

        

        if(visible) {
            if(!isChasing) {
                isChasing = true;
                lightComponent.color = lightChaseColor;
                agent.speed = chaseSpeed;
                audioSource.volume = chaseVolume;
            }

            currentTarget = playerCamera.transform;
            agent.destination = currentTarget.position;
        }

        

        //
        if(isChasing) {
            // If visible and within range, end game
            if(visible && Vector3.Distance(transform.position, playerCamera.transform.position) < killDistance) {
                Debug.Log("Found Player. Game Over");
            }

            // If reached player's last known location and not visible, 
            // set to not chasing and go to previous path index
            if(!visible && reachedTarget()) {
                // Return to patrol mode
                isChasing = false;
                lightComponent.color = lightPatrolColor;
                agent.speed = patrolSpeed;

                // Resume patrol
                currentTarget = patrolPath[currentPathIndex];
                agent.destination = currentTarget.position;

                audioSource.volume = patrolVolume;
            }
        }
        else {
            // Check if reached target. if yes, switch target to next index
            if(reachedTarget()) {
                currentPathIndex++;
                if(currentPathIndex >= patrolPath.Length) {
                    currentPathIndex = 0;
                }

                currentTarget = patrolPath[currentPathIndex];
                agent.destination = currentTarget.position;
            }
        }
        
        // Play audio for robot
        timeSinceLastPlay += Time.deltaTime;
        if(timeSinceLastPlay > (isChasing?chaseTimeBetweenPlays:patrolTimeBetweenPlays)) {
            audioSource.PlayOneShot(isChasing?chaseAudioClip:patrolAudioClip);
            timeSinceLastPlay = 0;
        }
    }

    private bool determinePlayerVisible() {
        bool visible = false;
        Vector3 point = light.transform.position;
        Vector3 direction = playerCamera.transform.position - light.transform.position;

        if(Vector3.Angle(light.transform.forward, direction) < fieldOfView/2) {
            int layermask = 0xFFFF;
            RaycastHit raycastHit;

            
            if(Physics.Raycast(point, direction, out raycastHit, viewDistance, layermask))
            {
                if(System.String.Compare(raycastHit.collider.tag, "Player") == 0) {
                    visible = true;
                }
            }
        }

        return visible;
    }


    private bool reachedTarget() {
        return Vector3.Distance(currentTarget.position, transform.position) < 1.7;
    }
}
