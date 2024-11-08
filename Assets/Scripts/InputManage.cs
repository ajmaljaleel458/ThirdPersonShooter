using UnityEngine;
using UnityEngine.InputSystem;

public class InputManage : MonoBehaviour
{
    public Vector2 mouseDelta = Vector2.zero;

    public Vector2 movement = Vector2.zero;

    public bool isSprinting = false;

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

}
