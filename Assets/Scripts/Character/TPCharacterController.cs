using NUnit.Framework.Constraints;
using UnityEngine;

public class TPCharacterController : MonoBehaviour
{
    public CharacterController characterController;

    public InputManage inputManager;

    public float movementSpeed = 3.0f;

    float verticalInput, horizontalInput;

    public float horizontalCameraSensi = 100f;

    public Animator animator;


    private Vector3 direction;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        GetDirectionAndMove();
        RotatePlayer();
    }

    private void GetDirectionAndMove()
    {
        horizontalInput = inputManager.movement.x;

        verticalInput = inputManager.movement.y;

        direction = transform.forward * verticalInput + transform.right * horizontalInput;

        if (inputManager.isSprinting) movementSpeed = 6.0f;
        else if (inputManager.movement == Vector2.zero) movementSpeed = 0.0f;
        else movementSpeed = 3.0f;

        animator.SetFloat("Speed", movementSpeed);

        characterController.Move(direction * movementSpeed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        float horizontalInput = Input.GetAxis("Mouse X");

        transform.Rotate(transform.up, horizontalInput * horizontalCameraSensi * Time.deltaTime);
    }

    private void OnApplicationFocus(bool focus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
