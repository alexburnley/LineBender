using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RestartLevel : MonoBehaviour
{

    public float restartDelay = 5.0f;

    public Transform loadingRoom;

    GameObject playerRig;

    // Start is called before the first frame update
    void Start()
    {
        playerRig = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Restart() {
        StartCoroutine(RestartDelayed());
    }

    IEnumerator RestartDelayed() {
        playerRig.transform.position = loadingRoom.position;
        playerRig.transform.rotation = loadingRoom.rotation;

        yield return new WaitForSeconds(restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
