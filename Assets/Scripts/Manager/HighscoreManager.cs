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
    
    public bool CalculateHighScore(int score)
    {
        currentHighscore = PlayerPrefs.GetInt("High Score", 0);
        if (score > currentHighscore) 
        {
            currentHighscore = score;
            PlayerPrefs.SetInt("High Score", currentHighscore);
            return true;
        }
        return false;
    }

    public int GetHighScore()
    {
        currentHighscore = PlayerPrefs.GetInt("High Score", 0);
        return currentHighscore;
    }
}