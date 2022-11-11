using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControlVR : MonoBehaviour
{
    // [SerializeField]
    //public Rigidbody hitbox;
    public CharacterController hitbox;
    public float moveSpeed = 5.0f;
    public float lookSensitivity = 1.0f;

    public GameObject playerCamera;

    // [SerializeField]
    public InputActionReference move;
    public InputActionReference look;

    private Vector2 moveDirection;
    private Vector2 lookDelta;


    private void Awake() {
        //playerControls = new LineBenderPlayer();
    }

    private void OnEnable() {
        //playerControls.Enable();
        //move = playerControls.Player.Move;
        move.action.Enable();
        //look = playerControls.Player.Look;
        look.action.Enable();
    }

    private void onDisable() {
        move.action.Disable();
        look.action.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
        lookDelta = look.action.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        //float upVelocity = hitbox.velocity.y;
        //hitbox.velocity =  playerCamera.transform.localToWorldMatrix * new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
        // hitbox.velocity = new Vector3(hitbox.velocity.x,upVelocity,hitbox.velocity.z);
        hitbox.SimpleMove( playerCamera.transform.localToWorldMatrix * new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed));

        Vector3 pos = transform.position;
        //transform.localPosition = new Vector3(0,0,0);
        //hitbox.position = pos;

        transform.rotation *= Quaternion.AngleAxis(lookDelta.x * lookSensitivity, Vector3.up);
    }
}
