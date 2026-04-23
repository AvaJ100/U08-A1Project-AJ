using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text ScoreText;
    public TMP_Text HealthText;

    public int starsCollected;
    public int playerHealth;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER TRIGGERED");

        ScoreText.text = "Stars: " + starsCollected;
        HealthText.text = "Health: " + playerHealth;

        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
  