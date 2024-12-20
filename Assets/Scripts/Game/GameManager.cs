using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;

    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        this.highScoreText.text += highScore.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        int emptyIndex = this.scoreText.text.IndexOf(" ");

        this.playerScore += scoreToAdd;
        this.scoreText.text = $"{this.scoreText.text.Substring(0, emptyIndex + 1)}{playerScore}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        AudioManager.Instance.StartAudio();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);

        AudioManager.Instance.StopAudio();
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
    }
}
