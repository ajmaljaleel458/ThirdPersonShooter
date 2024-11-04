using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public bool isSprinting = false;

    public Vector2 motion = Vector2.zero;

    public void OnMove(InputAction.CallbackContext context)
    {
        motion = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
            isSprinting = true;
        else
            isSprinting = false;
    }
}
