using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    public GameObject titleScreen;
    public Button restartButton; 
    public bool isGameActive;
    public List<GameObject> targets;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    
    public int lives;
    public TextMeshProUGUI livesText;

    bool pauseGame;
    public TextMeshProUGUI pauseText;

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseScene()
    {
        
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {     
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    void Update()
    {
        if(lives == 0)
        {
            GameOver();
        }
        
        livesText.text = "Lives: " + lives;

         if (Input.GetKeyDown(KeyCode.Space) && isGameActive == true)
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                Time.timeScale = 0;
                pauseText.gameObject.SetActive(true);

            }
            else
            {
                Time.timeScale = 1;
                pauseText.gameObject.SetActive(false);
            }
        }
    }
}
