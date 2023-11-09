using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool isMoving = false;
    public AudioSource hitSound;
    // Start is called before the first frame update
    void Start()
    {
        hitSound = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, 1);
        if (!isMoving && Input.anyKeyDown) {
            if (rand == 0) {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, 0f);
            } else {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0f);
            }
            isMoving = true;
        }
    }

    void OnCollisionEnter2D(Collision2D hit) {
        hitSound.Play();
        float dist1 = this.transform.position.y - GameObject.Find("Player").transform.position.y;
        float dist2 = this.transform.position.y - GameObject.Find("Player2").transform.position.y;

        if (hit.gameObject.name == "Player") {
            this.GetComponent<Rigidbody2D>().velocity += new Vector2(1f, dist1 * 2f);
        }
        if (hit.gameObject.name == "Player2") {
            this.GetComponent<Rigidbody2D>().velocity += new Vector2(-1f, dist2 * 2f);
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame()
    {
        ResetBall();
        isMoving = false;
        Start();
    }
}
