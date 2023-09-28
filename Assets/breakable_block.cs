using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    // block gets destroyed when colliding with ball
    private void OnCollisionEnter2D(Collision 2D collide) {

        if (OnCollisionEnter2D.gameObject.CompareTag ("breakable_block")) {

            Destroy (breakable_block);

        }

            
    }

}
