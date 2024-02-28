using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public bool isGameActive;
    
    public List<GameObject> targets;

    public TextMeshProUGUI gameOverText;

    private int score;
    public TextMeshProUGUI scoreText;
    
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive = true;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
