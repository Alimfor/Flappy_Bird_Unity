using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;

    public Text scoreText;

    public Text resultScoreText;

    public Text bestResultScoreText;

    public GameObject playButton;

    public GameObject gameOver;

    public GameObject resultTable;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        resultTable.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void Start()
    {
        bestResultScoreText.text = GetBestScore();
    }

    public void GameOver()
    {
        resultScoreText.text = scoreText.text;

        gameOver.SetActive(true);
        playButton.SetActive(true);
        resultTable.SetActive(true);

        string bestScore = GetBestScore();

        if (int.Parse(bestScore) < int.Parse(resultScoreText.text))
        {
            SetInt("bestScore", int.Parse(resultScoreText.text));
            bestResultScoreText.text = resultScoreText.text;
        }

        Pause();
    }

    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public string GetBestScore()
    {
        return PlayerPrefs.GetInt("bestScore").ToString();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
