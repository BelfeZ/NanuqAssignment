using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    [Header("Obstacle Configurations")]
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float minHeight = -1f;
    [SerializeField] private float maxHeight = 1f;

    [Header("Difficulty Configurations")]
    [SerializeField] private float increaseSpawnRate = 0.2f;
    [SerializeField] private int scorePerThreshold = 10;
    [SerializeField] private float maximumSpawnRate = 1f;

    [Header("Obstacle Materials")]
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Background Material (For pausing backgrounds)")]
    [SerializeField] private List<BackgroundScrolling> backgrounds;

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

    private void IncreaseDifficulty()
    {
        if (spawnRate - increaseSpawnRate >= maximumSpawnRate) spawnRate = spawnRate - increaseSpawnRate;

        else spawnRate = maximumSpawnRate;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Score : {score}";

        if(score % scorePerThreshold == 0) IncreaseDifficulty();
    }

    public void GameOver()
    {
        foreach (BackgroundScrolling obj in backgrounds)
        {
            obj.PauseBackground();
        }

        Debug.Log("Dead");
    }
}