using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponManager : MonoBehaviour
{
    public GameObject playerCamera;

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
            playerCamera.transform.Translate(new Vector3(0.0f, 0.0f, 100.0f));

            scope.SetActive(true);
            crossHair.SetActive(false);
        }

        if (scopeAction.WasReleasedThisFrame())
        {
            playerCamera.transform.Translate(new Vector3(0.0f, 0.0f, -100.0f));
            scope.SetActive(false);
            crossHair.SetActive(true);
        }
    }
}
