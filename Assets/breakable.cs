using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    private float directionOfHit;
    
    // block gets destroyed when colliding with ball
    private void OnCollisionEnter2D(Collision2D collide)
    {
            Vector2.Reflect(collide.relativeVelocity, collide.contacts[0].normal);
            Destroy (gameObject);
            WallSpawner.currentCubes--;
    }
    
    
}
