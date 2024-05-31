using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Ball ball;
    public float speedIncrease;
    public float increaseDelay;

    public int score = 0;
    public Text scoreText;

    public GameObject gamePanel;
    public GameObject gameOverPanel;

    public bool isGameStarted = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator IncreaseBallSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseDelay);

            ball.speed += ball.speed * speedIncrease;
        }
    }

    public void StartGame()
    {
        isGameStarted = true;
        StartCoroutine(IncreaseBallSpeed());
    }

    public void CollectDiamond()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void PauseGame()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

        ball.SwitchDirection();
    }

    public void GameOver()
    {
        isGameStarted = false;
        ball.gameObject.SetActive(false);

        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}