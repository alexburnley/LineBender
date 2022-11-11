using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlScript : MonoBehaviour
{
    public Rigidbody hitbox;
    public float moveSpeed = 5.0f;
    public float lookSensitivity = 1.0f;

    public GameObject playerCamera;

    public bool invertY = true;

    public LineBenderPlayer playerControls;

    private InputAction move;
    private InputAction look;




    private Vector2 moveDirection;
    private Vector2 lookDelta;


    private void Awake() {
        playerControls = new LineBenderPlayer();
    }

    private void OnEnable() {
        move = playerControls.Player.Move;
        move.Enable();
        look = playerControls.Player.Look;
        look.Enable();
    }

    private void onDisable() {
        move.Disable();
        look.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
        lookDelta = look.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        hitbox.velocity =  transform.localToWorldMatrix * new Vector3(moveDirection.x * moveSpeed, hitbox.velocity.y, moveDirection.y * moveSpeed);

        hitbox.rotation *= Quaternion.AngleAxis(lookDelta.x * lookSensitivity, Vector3.up);
        playerCamera.transform.rotation *= Quaternion.AngleAxis(lookDelta.y * lookSensitivity * (invertY? -1.0f : 1.0f), Vector3.right);
    }
}
