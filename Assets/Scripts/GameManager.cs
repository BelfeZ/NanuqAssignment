using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

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

    [Header("GUI Configurations")]
    [SerializeField] private int countsdownTime = 3;

    [Header("Obstacle Materials")]
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Background Material (For pausing backgrounds)")]
    [SerializeField] private List<BackgroundScrolling> backgrounds;

    [Header("GUI Materials")]
    [SerializeField] private TextMeshProUGUI countsdownText;
    [SerializeField] private GameObject gameOverPanel;

    private int score = 0;
    private List<ObstaclesController> obstacles = new List<ObstaclesController>();

    private void OnEnable()
    {
        StartCoroutine(StartCountdown());
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnObstacle));
    }

    private IEnumerator StartCountdown()
    {
        int countdown = countsdownTime;
        Time.timeScale = 0f;

        while(countdown > 0)
        {
            countsdownText.text = $"{countdown}";
            yield return new WaitForSecondsRealtime(1f);
            countdown--;
        }

        countsdownText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        InvokeRepeating(nameof(SpawnObstacle), spawnRate, spawnRate);
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

    public IEnumerator GameOver()
    {
        foreach (BackgroundScrolling obj in backgrounds)
        {
            obj.PauseBackground();
        }

        foreach (ObstaclesController obs in obstacles)
        {
            obs.StopObstacle();
        }

        CancelInvoke(nameof(SpawnObstacle));
        yield return new WaitForSecondsRealtime(1.5f);
        gameOverPanel.gameObject.SetActive(true);
    }

    public void RegisterObstacle(ObstaclesController obs)
    {
        obstacles.Add(obs);
    }

    public void UnregisterObstacle(ObstaclesController obs)
    {
        obstacles.Remove(obs);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}