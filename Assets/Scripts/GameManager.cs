using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public int health = 3;

    public GameObject gameOverPanel;

    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalHealthText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(true);
    }

    public void AddScore(int amount)
    {
        score += amount;

        Debug.Log("Score: " + score);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        finalScoreText.text = "Stars Collected: " + score;
        finalHealthText.text = "Lives Remaining: " + health;

        Time.timeScale = 0f;
    }

    public void RetryToTestLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("TestLevel");
    }
}
