using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Status (For pausing player)")]
    [SerializeField] private bool isPlaying;

    [Header("Player Configuration")]
    [SerializeField] private float playerGravity;
    [SerializeField] private float playerFlyStrength;

    private Vector3 direction;

    void Update()
    {
        if (isPlaying && Input.GetMouseButtonDown(0)) direction = Vector3.up * playerFlyStrength;

        if (isPlaying)
        {
            direction.y += playerGravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;
        }
    }
}
