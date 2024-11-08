using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponManager : MonoBehaviour
{
    public Camera playerCamera;

    InputAction scopeAction;

    public GameObject scope;
    public GameObject crossHair;


    private void Start()
    {
        scopeAction = InputSystem.actions.FindAction("Scopeing");
    }

    private void Update()
    {
        if (scopeAction.WasPressedThisFrame())
        {
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 5f, 10f);

            scope.SetActive(true);
            crossHair.SetActive(false);
        }

        if (scopeAction.WasReleasedThisFrame())
        {
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 60.0f, 10f);

            scope.SetActive(false);
            crossHair.SetActive(true);
        }
    }
}
