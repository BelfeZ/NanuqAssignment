using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    [Header("Obstacles Configuration")]
    [SerializeField] private float speed = 5f;

    private float leftEdge;

    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        FindAnyObjectByType<GameManager>().RegisterObstacle(this);
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < leftEdge)
        {
            FindAnyObjectByType<GameManager>().UnregisterObstacle(this);
            Destroy(gameObject);
        }
    }

    public void StopObstacle()
    {
        speed = 0f;
    }
}