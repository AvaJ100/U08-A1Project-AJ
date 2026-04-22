using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public GameObject gameOverPanel;
    public TMPro.TextMeshProUGUI finalScoreText;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // freeze game
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + score;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
