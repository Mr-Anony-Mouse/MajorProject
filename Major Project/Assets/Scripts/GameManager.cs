using UnityEngine;
using UnityEngine.UI; // Using the classic UI namespace
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverScreen;
    public PipeSpawner pipeSpawner; 

    private int score = 0;
    private bool isGameOver = false;

    void Start()
    {
        Time.timeScale = 1f;
        scoreText.text = "0";
        gameOverScreen.SetActive(false);
    }

    public void StartGame()
    {
        pipeSpawner.StartSpawning();
    }

    public void IncreaseScore()
    {
        if (!isGameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}