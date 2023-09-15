using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement2 : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Vector2 movement;

    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public float speed = 10.0f;
    public float boundY = 2.25f;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb.velocity;
        if (Input.GetKey(moveUp)){
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown)){
            vel.y = -speed;
        }
        else{
            vel.y = 0;
        }
        rb.velocity = vel;
        var pos = transform.position;
        if (pos.y > boundY){
            pos.y = boundY;
        }
        else if (pos.y < -boundY){
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}


