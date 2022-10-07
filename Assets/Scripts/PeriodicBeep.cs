using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicBeep : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;

    public float period;

    float timeSinceLastPlay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastPlay += Time.deltaTime;
        if(timeSinceLastPlay > period) {
            audioSource.PlayOneShot(audioClip);
            timeSinceLastPlay = 0;
        }
    }
}
