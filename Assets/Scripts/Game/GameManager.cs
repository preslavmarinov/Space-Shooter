using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public void AddScore(int scoreToAdd)
    {
        this.playerScore += scoreToAdd;
        this.scoreText.text = this.playerScore.ToString();
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
