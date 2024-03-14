using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float minSpeed = -5f;
    public float maxSpeed = -10f;
    private float fallingSpeed;

    public Rigidbody2D rb;
    public AudioSource audioSource;
    public AudioClip ScreamAudio;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fallingSpeed = Random.Range(minSpeed, maxSpeed);
    }


    private void Update()
    {
        rb.velocity = new Vector2(0, fallingSpeed);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("collided");
            audioSource.PlayOneShot(ScreamAudio);

        }

    }
}
