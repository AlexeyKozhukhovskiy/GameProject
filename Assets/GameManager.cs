using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject endPanel;
    public GameObject pausePanel;
    public Text currentScoreText;
    public Text bestScoreText;
    public Text scoreText;

    public int gameScore = 0;
    public static bool isGamePaused;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void AddPoint()
    {
        gameScore++;
        scoreText.text = gameScore.ToString();
    }
    public void StartGame()
    {
        isGamePaused = false;
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        Time.timeScale = 1f;
    }
    public void PlayerDie()
    {
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        isGamePaused = true;
        currentScoreText.text = gameScore.ToString();
        if (PlayerPrefs.GetInt("bestScore") < gameScore)
        {
            PlayerPrefs.SetInt("bestScore", gameScore);
        }
        bestScoreText.text = PlayerPrefs.GetInt("bestScore").ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        pausePanel.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    public void Play()
    {
        pausePanel.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
    }
}
