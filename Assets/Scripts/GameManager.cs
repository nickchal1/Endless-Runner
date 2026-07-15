using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text finalScoreText;
    [SerializeField] float pointsPerSecond = 10f;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gameOverPanel;

    bool gameOver;
    float score;
    bool gameStarted;

     void Update()
    {
        if (!gameStarted)
        {
            return;
        }

        score += pointsPerSecond * Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
}
    void Awake()
    {
        Time.timeScale = 0f;
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    public void StartGame()
    {   
    gameOver = false;
    gameStarted = true;
    score = 0f;

    scoreText.gameObject.SetActive(true);
    scoreText.text = "Score: 0";

    startPanel.SetActive(false);
    Time.timeScale = 1f;
    }

    public void GameOver()
    {
        if (gameOver) return;

        gameOver = true;

        gameStarted = false;
        finalScoreText.text = "Final Score: " + Mathf.FloorToInt(score);
        
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
}   
}
