using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponManager : MonoBehaviour
{
    public Camera playerCamera;

    InputAction scopeAction;
    InputAction shootAction;

    public bool isScoped = false;

    public GameObject scope;
    public GameObject crossHair;

    public int Damage = 100;

    public GameObject RayCastOrigin;

    private void Start()
    {
        scopeAction = InputSystem.actions.FindAction("Scopeing");

        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    private void Update()
    {
        if (scopeAction.WasPressedThisFrame())
        {
            isScoped = true;

            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 5f, 10f);

            scope.SetActive(true);
            crossHair.SetActive(false);
        }

        if (scopeAction.WasReleasedThisFrame())
        {
            isScoped = false;

            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 60.0f, 10f);

            scope.SetActive(false);
            crossHair.SetActive(true);
        }

        if (shootAction.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(RayCastOrigin.transform.position, RayCastOrigin.transform.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.transform.CompareTag("Eanemy"))
            {
                hitInfo.transform.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
