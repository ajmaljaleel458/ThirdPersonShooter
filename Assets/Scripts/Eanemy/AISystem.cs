using UnityEngine;

public class AISystem : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private float Damping = 6.0f;


    public float TriggerRadius = 10f;
    public float LookRadius = 15f;

    public float distance;

    private Transform PlayerTransform;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        PlayerTransform = player.transform;

        distance = Vector3.Distance(transform.position, PlayerTransform.transform.position);

        if (distance <= TriggerRadius)
        {
            FocusOnPlayer();
            RunAfterPlayer();
        }

        if (distance > TriggerRadius && distance <= LookRadius)
        {
            FocusOnPlayer();
        }
    }

    void FocusOnPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
    }

    void RunAfterPlayer()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
