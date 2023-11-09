using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public float spawnInterval = 1f;
    private float timeSinceLastSpawn = 0f;
    private bool _isGameOver = false;
    GameManager _gameManager;
    private int gameManagerPlayerScore1;
    private int gameManagerPlayerScore2;
    private bool correctMode;   

    // Update is called once per frame
    void Update()
    {
        // Variables to have the score update in real time
        gameManagerPlayerScore1 = GameManager.PlayerScore1;
        gameManagerPlayerScore2 = GameManager.PlayerScore2;

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "LevelTwo")
        {
            correctMode = true;
            print("LevelTwo");
        }
        // If either player has 3 points, the game is over
        if (gameManagerPlayerScore1 == 3 || gameManagerPlayerScore2 == 3)
        {
            _isGameOver = true;
            
        }
        // If the game is not over, spawn walls every spawnInterval seconds and the correct mode is selected.
        if (correctMode)
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= spawnInterval && _isGameOver == false)
            {
                Vector2 spawnPos = new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f));
                Instantiate(wallPrefab, spawnPos, Quaternion.identity);
                timeSinceLastSpawn = 0f;
                spawnInterval *= 0.95f;
            }
        }
        
        
    }

    public void ResetGame()
    {
        // Reset the game by resetting the spawn interval and time since last spawn
        spawnInterval = 5f;
        timeSinceLastSpawn = 0f;
        _isGameOver = false;
        
    }
}
