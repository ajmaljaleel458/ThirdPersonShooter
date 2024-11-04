using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputManager inputManager;

    public float speed;

    public Animator animator;

    void Update()
    {
        if (inputManager.motion == Vector2.zero)
            speed = 0.0f;
        else if (inputManager.isSprinting)
            speed = 4.0f;
        else
            speed = 2.0f;

        animator.SetFloat("Speed", speed);

        transform.Translate(new Vector3(inputManager.motion.x, 0.0f, inputManager.motion.y) * speed * Time.deltaTime);
    }
}
