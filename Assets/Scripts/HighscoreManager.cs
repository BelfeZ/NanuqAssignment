using TMPro;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager instance;
    private int currentHighscore;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void CheckHighScore(int score)
    {
        if(score > currentHighscore) currentHighscore = score;
    }

    public int GetHighScore()
    {
        return currentHighscore;
    }
}