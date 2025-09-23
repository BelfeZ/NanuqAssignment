using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuManager : MonoBehaviour
{
    [Header("Highscore Materials")]
    [SerializeField] private TextMeshProUGUI highscoreText;

    [Header("Menu Materials")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject highscorePanel;
    [SerializeField] private GameObject SoundOffButton;
    [SerializeField] private GameObject SoundOnButton;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void StartButton()
    {
        SoundManager.instance.PlayVfx(0);
        SceneManager.LoadScene("Game");
    }

    public void MenuButton()
    {
        SoundManager.instance.PlayVfx(0);
        SceneManager.LoadScene("Mainmenu");
    }

    public void HighscoreButton()
    {
        SoundManager.instance.PlayVfx(0);
        highscoreText.text = $"{PlayerPrefs.GetInt("High Score", 0)}";
        menuPanel.gameObject.SetActive(false);
        highscorePanel.gameObject.SetActive(true);
    }

    public void BackButton()
    {
        SoundManager.instance.PlayVfx(0);
        menuPanel.gameObject.SetActive(true);
        highscorePanel.gameObject.SetActive(false);
    }

    public void ToggleSoundButton(bool close)
    {
        if (close) 
        {
            SoundManager.instance.MuteSounds(true);
            SoundOffButton.gameObject.SetActive(false);
            SoundOnButton.gameObject.SetActive(true);
        }
        else
        {
            SoundManager.instance.MuteSounds(false);
            SoundOffButton.gameObject.SetActive(true);
            SoundOnButton.gameObject.SetActive(false);
        }
    }

    public void ExitButton()
    {
        SoundManager.instance.PlayVfx(0);
        Application.Quit();
    }
}