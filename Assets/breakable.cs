using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    // block gets destroyed when colliding with ball
    private void OnCollisionEnter2D(Collision2D collide) {

            Destroy (gameObject);
            
    }

}
