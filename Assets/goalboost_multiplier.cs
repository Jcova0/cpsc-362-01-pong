using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplierPowerUp : MonoBehaviour
{
    public int scoreMultiplier = 2;
    public float duration = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
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
                gameManager.apply_score_multi(scoreMultiplier);
            }

            // Deactivate the power-up
            gameObject.SetActive(false);

            // Schedule a method to deactivate the effect after a duration
            Invoke("DeactivatePowerUp", duration);
        }
        // Get lastPlayerHit from BallMovement.cs
        string lastPlayerHit = BallMovement.lastPlayerHit;
        Debug.Log(lastPlayerHit);
    }

    void DeactivatePowerUp()
    {
        // Deactivate the power-up for potential reuse
        gameObject.SetActive(true);
    }
    
}
