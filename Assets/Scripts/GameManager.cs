using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header("Score")]
    public int score = 0;
	public Text scoreText;
	public int highscore;
	public Text highScoreText;

	[Header("Game Over")]
	public GameObject gameOverPanel;
    public Text gameOverPanelScoreText;
    public Text gameOverPanelHighScoreText;

    private void Awake()
	{
		gameOverPanel.SetActive(false);
		GetHighScore();

    }

	private void GetHighScore()
	{
        highscore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "Best : " + highscore;
    }
	public void IncreaseScore(int points)
	{
		score += points;
        scoreText.text = score.ToString();

		if (score > highscore)
		{
			PlayerPrefs.SetInt("Highscore", score);
			highScoreText.text = "Best : " + score.ToString();
		}
	}

	public void OnBombHit()
	{
		Time.timeScale = 0;
		gameOverPanelScoreText.text = "Score : " +score.ToString();
        gameOverPanelHighScoreText.text = "Best : " + highscore.ToString();
        gameOverPanel.SetActive(true);    }

	public void RestartGame()
	{

		score = 0;
		scoreText.text = score.ToString();

		foreach ( GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
		{
			Destroy(g);
		}
        gameOverPanel.SetActive(false);
        gameOverPanelScoreText.text = "Score : 0";
        Time.timeScale = 1;
	}
}
