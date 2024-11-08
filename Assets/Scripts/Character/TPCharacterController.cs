using NUnit.Framework.Constraints;
using UnityEngine;

public class TPCharacterController : MonoBehaviour
{
    public CharacterController characterController;

    public float movementSpeed = 3.0f;

    float verticalInput, horizontalInput;

    public float horizontalCameraSensi = 100f;


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
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        direction = transform.forward * verticalInput + transform.right * horizontalInput;

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
