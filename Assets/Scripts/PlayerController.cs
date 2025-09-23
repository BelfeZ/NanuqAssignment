using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Configuration")]
    [SerializeField] private float playerGravity;
    [SerializeField] private float playerFlyStrength;

    [Header("Player Status (For pausing player)")]
    [SerializeField] private bool isPlaying;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") 
        { 
            FindAnyObjectByType<GameManager>().GameOver(); 
        }

        if (collision.gameObject.tag == "Score")
        {
            FindAnyObjectByType<GameManager>().IncreaseScore();
        }
    }
}