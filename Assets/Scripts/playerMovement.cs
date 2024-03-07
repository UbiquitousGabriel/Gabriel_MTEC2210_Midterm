using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // public AudioSource (PUT AUDIO NAME HERE);
    public float speed = 5;
    public AudioSource audioSource;
    public AudioClip ChompAudio;
    public AudioClip ScreamAudio;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");

        transform.Translate(speed * Time.deltaTime * xMove, 0, 0);

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            //Debug.Log("collided");
            Destroy(gameObject);
            audioSource.PlayOneShot(ScreamAudio);

        }


        if (collision.tag == "Pearl")
        {
            // (AUDIO NAME HERE).Play()
            //var renderer = GetComponent<Renderer>();
            //if (renderer != null)
            //{
            //    renderer.enabled = false;
            //}
            audioSource.PlayOneShot(ChompAudio);
            Destroy(collision.gameObject/*,(AUDIO NAME HERE).clip.length*/);
            gameManager.IncreaseScore();
        }

        if (collision.tag == "Hazard")
        {
            //Debug.Log("collided");
            Debug.Log("Transition");
        }
    }
}
