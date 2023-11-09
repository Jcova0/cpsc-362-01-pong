using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplierPowerUp : MonoBehaviour
{
    public int scoreMultiplier = 2;
    public float duration = 10.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Power-up collided with " + other.name);
        if (other.CompareTag("Ball")) // || other.CompareTag("Player2"))
        {
            Debug.Log("if statement for player1 or player2");
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
    }

    void DeactivatePowerUp()
    {
        // Deactivate the power-up for potential reuse
        //gameObject.SetActive(true);
    }
}
