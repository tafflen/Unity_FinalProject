using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int totalScore = 50; // You can change based on your level
    public TextMeshProUGUI scoreText;
    public GameObject QuestionPanel;  // ✅ This must be a GameObject


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        if (score >= totalScore)
        {
            LevelManager.Instance.ShowLevelCompletePanel(); 
        }

        if (score <= 0)
        {
            ShowQuestionPanel();
        }
    }

    public void ReduceScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            // scoreText.text = "Score: " + score;
            scoreText.text = "Score: " + score + " / " + totalScore;

    }

    void ShowQuestionPanel()
{
    QuestionPanel.SetActive(true);

    Time.timeScale = 0f; // Pause the game if needed
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}


    public void ResumeGame()
    {
        QuestionPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        score = 10; // Optional: restore minimal score
    }

    // public void GameOver()
    // {
    //     Debug.Log("Game Over");
    //     // Handle loss screen or restart
    // }

    public void GameOver()
{
    LevelManager.ShowLevelFailedPanel();
    Time.timeScale = 0f;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
}

}
