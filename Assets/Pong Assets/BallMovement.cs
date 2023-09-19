using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, 2);

        if (rand == 0) {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, 0f);
        } else {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D hit) {
        float dist1 = this.transform.position.y - GameObject.Find("Player").transform.position.y;
        float dist2 = this.transform.position.y - GameObject.Find("Player2").transform.position.y;

        if (hit.gameObject.name == "Player") {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, dist1 * 2f);
        }
        if (hit.gameObject.name == "Player2") {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, dist2 * 2f);
        }
    }
}
