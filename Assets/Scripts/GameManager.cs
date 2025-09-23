using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Obstacle Material")]
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Obstacle Configuration")]
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 1f;

    private int score = 0;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnObstacle), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnObstacle));
    }

    private void SpawnObstacle()
    {
        float y = Random.Range(minHeight, maxHeight);
        Vector3 spawnpos = transform.position;
        spawnpos.y = y;
        Instantiate(obstaclePrefab, spawnpos, Quaternion.identity);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Score : {score}";
    }

    public void GameOver()
    {
        Debug.Log("Dead");
    }
}
