using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform crossHair;         
    public float verticalCameraSensi = 100f; 

    public WeaponManager weaponManager;

    public float minAngle = -30f;    
    public float maxAngle = 30f;

    private float currentAngle = 0f;

    void Update()
    {
        if (weaponManager.isScoped) verticalCameraSensi = 30f;
        else verticalCameraSensi = 100f;
        

        float verticalInput = Input.GetAxis("Mouse Y");

        float angle = verticalInput * verticalCameraSensi * Time.deltaTime;

        float newAngle = Mathf.Clamp(currentAngle + angle, minAngle, maxAngle);

        float angleToRotate = newAngle - currentAngle;
        transform.RotateAround(crossHair.position, transform.right, -angleToRotate);

        currentAngle = newAngle;
    }
}

