using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreMultiplierPowerUp : MonoBehaviour
{
    public int scoreMultiplier = 2;
    public float duration = 10.0f;
    public float speed = 0.1f;
    public float distance = 0.1f;
    string lastPlayerHit = BallMovement.lastPlayerHit;
    private Vector2 startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the power up object
        GameObject powerUp = GameObject.FindGameObjectWithTag("PowerUp");
        // Get the start position of the power up    
        startPos = transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Ball"))
        {
            // Apply the score multiplier effect to the GameManager
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                Debug.Log("Power-up triggered!");
                gameManager.apply_score_multi(scoreMultiplier, lastPlayerHit);
            }

            // Deactivate the power-up
            gameObject.SetActive(false);

            // Schedule a method to deactivate the effect after a duration
            Invoke("DeactivatePowerUp", duration);
        }
        // Get lastPlayerHit from BallMovement.cs
        
        Debug.Log(lastPlayerHit);
    }

    void DeactivatePowerUp()
    {
        // Deactivate the power-up for potential reuse
        gameObject.SetActive(true);
    }

    void Update()
    {
        Vector2 pos = startPos; 
        pos.x += Mathf.Sin(Time.time * speed) * distance;
        transform.position = pos;
        
    }
}
