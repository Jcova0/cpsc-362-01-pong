using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour
{
    private float directionOfHit;
    // block gets destroyed when colliding with ball
    private void OnCollisionEnter2D(Collision2D collide)
    {
            
            directionOfHit = collide.contacts[0].point.x - transform.position.x;
            print(directionOfHit);
            if(directionOfHit > 0)
            {
                print("right");
                collide.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(4, 0);
            }
            else
            {
                print("left");
                collide.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(-4, 0);
            }
            //collide.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2(8, 0);
            Destroy (gameObject);
            
    }
    
    
}
