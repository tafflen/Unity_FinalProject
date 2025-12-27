using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject LevelCompletePanel;
    public static GameObject LevelFailedPanel;
    [SerializeField] private GameObject LevelFailedPanelReference;


    private void Awake()
    {
        // Singleton pattern setup
        if (Instance == null)
        {
            Instance = this;
            // Uncomment below if you want it to persist across scenes
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LevelFailedPanel = LevelFailedPanelReference;
    }

    public void ShowLevelCompletePanel()
    {
        if (LevelCompletePanel != null)
            LevelCompletePanel.SetActive(true);

    }

    public static void ShowLevelFailedPanel()
    {
        if (LevelFailedPanel != null)
            LevelFailedPanel.SetActive(true);
    }

    public void ReplayGame()
{
    Time.timeScale = 1f;  // Resume game
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
   SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}


    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // public void LoadNextLevel()
    // {
    //     int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    //     if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
    //     {
    //         SceneManager.LoadScene(nextSceneIndex);
    //     }
    //     else
    //     {
    //         Debug.Log("No more levels to load.");
    //         // Optionally show a "Game Completed" UI
    //     }
    //}
}


