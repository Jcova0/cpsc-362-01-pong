using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable_block : MonoBehaviour
{
    // block gets destroyed when colliding with ball
    private void OnCollisionEnter2D(Collision 2D collide) {

        Destroy (collide.gameObject);
    }

}
