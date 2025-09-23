using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuManager : MonoBehaviour
{
    [Header("For transition each panel")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject highscorePanel;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void HighscoreButton()
    {
        menuPanel.gameObject.SetActive(false);
        highscorePanel.gameObject.SetActive(true);
    }

    public void BackButton()
    {
        menuPanel.gameObject.SetActive(true);
        highscorePanel.gameObject.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}