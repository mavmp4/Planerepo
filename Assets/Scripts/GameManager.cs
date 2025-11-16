using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
    public GameObject cloudPrefab;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;   // Change one

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        UpdateScoreText(); // Change 2
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();

        if (enemyOnePrefab != null)
            InvokeRepeating("CreateEnemy", 1f, 3f);
        else
            Debug.LogWarning("enemyOnePrefab not assigned in GameManager.");

        // Enemy two: starts at 2s, repeats every 5s (different timing)
        if (enemyTwoPrefab != null)
            InvokeRepeating("CreateEnemyTwo", 2f, 5f);
        else
            Debug.LogWarning("enemyTwoPrefab not assigned in GameManager.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

void CreateEnemyTwo()
    {
        // Spawn enemy two near the top at a random X position (different spawn timing/pattern)
        Instantiate(enemyTwoPrefab,
            new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize) * 0.9f, verticalScreenSize, 0),
            Quaternion.identity);
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
        
    }
    public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        UpdateScoreText(); // Change 3
    }
    //change 4
    public void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}
