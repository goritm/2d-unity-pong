using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float difficultyMultiplier = 1.2f;
    public float minXSpeed = 0.8f;
    public float maxXSpeed = 1.2f;
    public float minYSpeed = 0.8f;
    public float maxYSpeed = 1.2f;

    private Rigidbody2D ballRigidbody;
    // Use this for initialization
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballRigidbody.velocity = new Vector2(
            Random.Range(minXSpeed, maxXSpeed) * (Random.value > 0.5f ? -1 : 1),
            Random.Range(minYSpeed, maxYSpeed) * (Random.value > 0.5f ? -1 : 1) //Operador ternario
        );
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Limit")
        {
            GetComponent<AudioSource>().Play();
            //Choque con limite de arriba
            if (other.transform.position.y > transform.position.y && ballRigidbody.velocity.y > 0)
            {
                ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, -ballRigidbody.velocity.y);
            }
            //Choque con limite de abajo
            if (other.transform.position.y < transform.position.y && ballRigidbody.velocity.y < 0)
            {
                ballRigidbody.velocity = new Vector2(ballRigidbody.velocity.x, -ballRigidbody.velocity.y);
            }
        }
        else if (other.tag == "Paddle")
        {
            GetComponent<AudioSource>().Play();
            //Choque con paleta de la izquierda
            if (other.transform.position.x < transform.position.x && ballRigidbody.velocity.x < 0)
            {
                ballRigidbody.velocity = new Vector2(
                    -ballRigidbody.velocity.x * difficultyMultiplier,
                    ballRigidbody.velocity.y * difficultyMultiplier
                );
            }
            //Choque con paleta de la derecha
            if (other.transform.position.x > transform.position.x && ballRigidbody.velocity.x > 0)
            {
                ballRigidbody.velocity = new Vector2(
                    -ballRigidbody.velocity.x * difficultyMultiplier,
                    ballRigidbody.velocity.y * difficultyMultiplier
                );
            }
        }
    }
}
